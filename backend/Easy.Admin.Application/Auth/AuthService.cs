using Easy.Admin.Application.Auth.Dtos;
using Easy.Admin.Application.Config;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Extensions.Caching.Memory;
using MrHuo.OAuth.QQ;

namespace Easy.Admin.Application.Auth;
/// <summary>
/// 用户授权
/// </summary>
[AllowAnonymous]
public class AuthService : IDynamicApiController
{
    private readonly ISqlSugarRepository<SysUser> _sysUseRepository;
    private readonly CustomConfigService _customConfigService;
    private readonly ICaptcha _captcha;
    private readonly IMemoryCache _cache;
    private readonly ISqlSugarRepository<AuthAccount> _accountRepository;
    private readonly IIdGenerator _idGenerator;
    private readonly IEasyCachingProvider _easyCachingProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// 第三方授权缓存
    /// </summary>
    private const string OAuthKey = "oauth.";

    private const string OAuthRedirectKey = "oauth.redirect.";
    public AuthService(ISqlSugarRepository<SysUser> sysUseRepository,
        CustomConfigService customConfigService,
        ICaptcha captcha,
        ISqlSugarRepository<AuthAccount> accountRepository,
        IMemoryCache cache,
        IIdGenerator idGenerator,
        IEasyCachingProvider easyCachingProvider,
        IHttpContextAccessor httpContextAccessor)
    {
        _sysUseRepository = sysUseRepository;
        _customConfigService = customConfigService;
        _captcha = captcha;
        _cache = cache;
        _accountRepository = accountRepository;
        _idGenerator = idGenerator;
        _easyCachingProvider = easyCachingProvider;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// 系统用户登录
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task SignIn(AdminLoginInput dto)
    {
        bool validate = _captcha.Validate(dto.Id, dto.Code);
        if (!validate)
        {
            throw Oops.Bah("验证码错误");
        }

        string signInErrorCacheKey = $"login.error.{dto.Account}";
        CacheValue<int> value = await _easyCachingProvider.GetAsync<int>(signInErrorCacheKey);
        var setting = await _customConfigService.Get<SysSecuritySetting>();
        //5分钟内连续验证密码失败超过4次将限制用户尝试
        if (value.HasValue && value.Value > (setting?.Times ?? 4))
        {
            throw Oops.Bah("由于您多次登录失败，系统已限制账户登录");
        }
        SysUser user = await _sysUseRepository.GetFirstAsync(x => x.Account == dto.Account);
        if (user == null)
        {
            throw Oops.Bah("用户名或密码错误");
        }

        var context = _httpContextAccessor.HttpContext;
        if (user.Status == AvailabilityStatus.Disable || (user.LockExpired.HasValue && DateTime.Now < user.LockExpired))
        {
            throw Oops.Bah("您的账号被锁定");
        }

        if (user.Password != MD5Encryption.Encrypt($"{_idGenerator.Encode(user.Id)}{dto.Password}"))
        {
            await _easyCachingProvider.SetAsync(signInErrorCacheKey, value.Value + 1, TimeSpan.FromMinutes(5));
            throw Oops.Bah("用户名或密码错误");
        }
        long uniqueId = _idGenerator.NewLong();
        string token = JWTEncryption.Encrypt(new Dictionary<string, object>()
        {
            [AuthClaimsConst.AuthIdKey] = user.Id,
            [AuthClaimsConst.AccountKey] = user.Account,
            [AuthClaimsConst.UuidKey] = uniqueId,
            [AuthClaimsConst.AuthPlatformTypeKey] = AuthPlatformType.Manager
        });
        // 获取刷新 token
        var refreshToken = JWTEncryption.GenerateRefreshToken(token);
        // 设置响应报文头
        context.SigninToSwagger(token);
        context!.Response.Headers["access-token"] = token;
        context.Response.Headers["x-access-token"] = refreshToken;
    }

    /// <summary>
    /// 博客用户登录
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="referer">地址</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<string> SignInBlog(AdminLoginInputre dto)
    {


        bool validate = _captcha.Validate(dto.Id, dto.Code);
        if (!validate)
        {
            throw Oops.Bah("验证码错误");
        }

        string signInErrorCacheKey = $"login.error.{dto.Account}";
        CacheValue<int> value = await _easyCachingProvider.GetAsync<int>(signInErrorCacheKey);
        var setting = await _customConfigService.Get<SysSecuritySetting>();
        //5分钟内连续验证密码失败超过4次将限制用户尝试
        if (value.HasValue && value.Value > (setting?.Times ?? 4))
        {
            throw Oops.Bah("由于您多次登录失败，系统已限制账户登录");
        }
        SysUser user = await _sysUseRepository.GetFirstAsync(x => x.Account == dto.Account);
        if (user == null)
        {
            throw Oops.Bah("用户名或密码错误");
        }

        var context = _httpContextAccessor.HttpContext;
        if (user.Status == AvailabilityStatus.Disable || (user.LockExpired.HasValue && DateTime.Now < user.LockExpired))
        {
            throw Oops.Bah("您的账号被锁定");
        }

        if (user.Password != MD5Encryption.Encrypt($"{_idGenerator.Encode(user.Id)}{dto.Password}"))
        {
            await _easyCachingProvider.SetAsync(signInErrorCacheKey, value.Value + 1, TimeSpan.FromMinutes(5));
            throw Oops.Bah("用户名或密码错误");
        }
        string code = _idGenerator.Encode(_idGenerator.NewLong());
        AuthAccount account;
        switch ("email")
        {
            case "email":
              
                
               
                account = await _accountRepository.AsQueryable().FirstAsync(x => x.OAuthId == user.Id.ToString() && SqlFunc.ToLower(x.Type) == "email");
                var gender = Gender.Unknown;
                if (account != null)
                {
                   
                }
                else
                {
                    account = await _accountRepository.InsertReturnEntityAsync(new AuthAccount()
                    {
                        Gender = gender,
                        Avatar = "http://192.168.1.101:8088/oss/2024/04/24/YW4RKaNW5m.jpg",
                        Name = user.Account,
                        OAuthId = user.Id.ToString(),
                        Type = "email"
                    });
                }
                break;

            default:
                throw Oops.Bah("无效请求");
        }
        string key = $"{OAuthKey}{code}";
        await _easyCachingProvider.SetAsync(key, account, TimeSpan.FromMinutes(3));

        await _easyCachingProvider.SetAsync($"{OAuthRedirectKey}{code}", dto.referer, TimeSpan.FromMinutes(5));
        string url = (await _easyCachingProvider.GetAsync<string>($"{OAuthRedirectKey}{code}")).Value;
        string redirect = url.Contains("?") ? $"{url}&code={code}" : $"{url}?code={code}";
        return redirect;
    }

    /// <summary>
    /// 获取验证码
    /// </summary>
    /// <param name="id">验证码唯一id</param>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Captcha([FromQuery] string id)
    {
        var data = _captcha.Generate(id);
        var stream = new MemoryStream(data.Bytes);
        return new FileStreamResult(stream, "image/gif");
    }
    /// <summary>
    /// 发送邮件并获取验证码
    /// </summary>
    /// <param name="Email"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task ShenEmailAsunc(string Email)
    {
        string verificationCode = EmailSignIn.GenerateVerificationCode(); // 生成随机验证码

        // 在此处添加逻辑将验证码保存到数据库或缓存中
        //string code = _captcha.Generate(Email).Code;
        // 发送包含验证码的邮件
        await EmailSignIn.SendVerificationEmail(Email, verificationCode);
        _cache.Set(Email, verificationCode, TimeSpan.FromMinutes(3));

    }

    /// <summary>
    /// 发送邮件并获取验证码
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task Register(Risuget dto)
    {

        if (_cache.TryGetValue(dto.Email, out string storedVerificationCode))
        {
            // 验证码匹配则返回true，否则返回false
            if (storedVerificationCode == dto.Code)
            {
                var id = _idGenerator.NewLong();
                
                var sysu = new SysUser()
                {
                    Id = id,
                    Account = dto.Email,
                    CreatedTime = DateTime.Now,
                    Password = MD5Encryption.Encrypt($"{_idGenerator.Encode(id)}{dto.Password}"),
                    Email = dto.Email,
                    CreatedUserId = 123,
                    Name = "li",


                };
                await _sysUseRepository.InsertAsync(sysu);

            }
        }
        else { 
        throw Oops.Bah("用户名或密码错误");
        }

    }

}