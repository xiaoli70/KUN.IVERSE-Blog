﻿using Easy.Admin.Application.Auth;
using Easy.Admin.Application.Client.Dtos;
using Furion.UnifyResult;

namespace Easy.Admin.Application.Client;
/// <summary>
/// 博客文章
/// </summary>
[ApiDescriptionSettings("博客前端接口")]
[AllowAnonymous]
public class ArticleController : IDynamicApiController
{
    private readonly ISqlSugarRepository<Tags> _tagsRepository;
    private readonly ISqlSugarRepository<Article> _articleRepository;
    private readonly AuthManager _authManager;
    private readonly ISqlSugarRepository<Categories> _categoryRepository;
    private readonly ISqlSugarRepository<AuthAccount> _authAccountRepository;
    private readonly ISqlSugarRepository<FriendLink> _friendLinkRepository;

    public ArticleController(ISqlSugarRepository<Tags> tagsRepository,
        ISqlSugarRepository<Article> articleRepository,
        AuthManager authManager,
        ISqlSugarRepository<Categories> categoryRepository,
        ISqlSugarRepository<AuthAccount> authAccountRepository,
        ISqlSugarRepository<FriendLink> friendLinkRepository)
    {
        _tagsRepository = tagsRepository;
        _articleRepository = articleRepository;
        _authManager = authManager;
        _categoryRepository = categoryRepository;
        _authAccountRepository = authAccountRepository;
        _friendLinkRepository = friendLinkRepository;
    }

    /// <summary>
    /// 文章表查询
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PageResult<ArticleOutput>> Get([FromQuery] ArticleListQueryInput dto)
    {
        if (dto.TagId.HasValue)
        {
            var tag = await _tagsRepository.AsQueryable().Where(x => x.Id == dto.TagId && x.Status == AvailabilityStatus.Enable).Select(x => new { x.Name, x.Cover }).FirstAsync();
            UnifyContext.Fill(new { tag.Name, tag.Cover });
        }

        if (dto.CategoryId.HasValue)
        {
            var category = await _categoryRepository.AsQueryable().Where(x => x.Id == dto.CategoryId && x.Status == AvailabilityStatus.Enable).Select(x => new { x.Name, x.Cover }).FirstAsync();
            UnifyContext.Fill(new { category.Name, category.Cover });
        }
        return await _articleRepository.AsQueryable().LeftJoin<ArticleCategory>((article, ac) => article.Id == ac.ArticleId)
              .InnerJoin<Categories>((article, ac, c) => ac.CategoryId == c.Id && c.Status == AvailabilityStatus.Enable)
              .Where(article => article.Status == AvailabilityStatus.Enable && article.PublishTime <= SqlFunc.GetDate())
              .Where(article => article.ExpiredTime == null || SqlFunc.GetDate() < article.ExpiredTime)
              .WhereIF(dto.CategoryId.HasValue, (article, ac) => ac.CategoryId == dto.CategoryId)
              .WhereIF(!string.IsNullOrWhiteSpace(dto.Keyword), article => article.Title.Contains(dto.Keyword) || article.Summary.Contains(dto.Keyword) || article.Content.Contains(dto.Keyword))
              .WhereIF(dto.TagId.HasValue,
                  article => SqlFunc.Subqueryable<Tags>().InnerJoin<ArticleTag>((tags, at) => tags.Id == at.TagId)
                      .Where((tags, at) => tags.Status == AvailabilityStatus.Enable && at.ArticleId == article.Id && tags.Id == dto.TagId).Any())
              .OrderByDescending(article => article.IsTop)
              .OrderBy(article => article.Sort)
              .OrderByDescending(article => article.PublishTime)
              .Select((article, ac, c) => new ArticleOutput
              {
                  Id = article.Id,
                  Title = article.Title,
                  CategoryId = c.Id,
                  CategoryName = c.Name,
                  IsTop = article.IsTop,
                  CreationType = article.CreationType,
                  Summary = article.Summary,
                  Cover = article.Cover,
                  PublishTime = article.PublishTime,
                  Tags = SqlFunc.Subqueryable<Tags>().InnerJoin<ArticleTag>((tags, at) => tags.Id == at.TagId)
                      .Where((tags, at) => tags.Status == AvailabilityStatus.Enable && at.ArticleId == article.Id)
                      .ToList(tags => new TagsOutput
                      {
                          Id = tags.Id,
                          Name = tags.Name,
                          Color = tags.Color,
                          Icon = tags.Icon
                      })
              }).ToPagedListAsync(dto);
    }

    /// <summary>
    /// 标签列表
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<TagsOutput>> Tags()
    {
        return await _tagsRepository.AsQueryable().Where(x => x.Status == AvailabilityStatus.Enable)
              .OrderBy(x => x.Sort)
              .Select(x => new TagsOutput
              {
                  Id = x.Id,
                  Icon = x.Icon,
                  Name = x.Name,
                  Color = x.Color
              }).ToListAsync();
    }

    /// <summary>
    /// 文章栏目分类
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<CategoryOutput>> Categories()
    {
        var queryable = _articleRepository.AsQueryable().Where(a => a.Status == AvailabilityStatus.Enable && a.PublishTime <= SqlFunc.GetDate() && (a.ExpiredTime == null || SqlFunc.GetDate() < a.ExpiredTime));
        return await _categoryRepository.AsQueryable().LeftJoin<ArticleCategory>((c, ac) => c.Id == ac.CategoryId)
              .LeftJoin(queryable, (c, ac, a) => ac.ArticleId == a.Id)
              .Where(c => c.Status == AvailabilityStatus.Enable)
              .WithCache()
              .GroupBy(c => new { c.Id, c.ParentId, c.Name, c.Sort })
              .Select((c, ac, a) => new CategoryOutput
              {
                  Id = c.Id,
                  ParentId = c.ParentId,
                  Sort = c.Sort,
                  Name = c.Name,
                  Total = SqlFunc.AggregateCount(a.Id)
              })
              .MergeTable()
              .OrderBy(x => x.Sort)
              .OrderBy(x => x.ParentId)
              .OrderBy(x => x.Id)
              .ToListAsync();
    }

    /// <summary>
    /// 文章信息统计
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ArticleReportOutput> Report()
    {
        //统计文章数量
        int articleCount = await _articleRepository.AsQueryable()
            .Where(x => x.Status == AvailabilityStatus.Enable && (x.ExpiredTime == null || SqlFunc.GetDate() < x.ExpiredTime))
            .Where(x => x.PublishTime <= SqlFunc.GetDate())
            .CountAsync();

        //标签统计
        int tagCount = await _tagsRepository.AsQueryable().Where(x => x.Status == AvailabilityStatus.Enable).CountAsync();
        //栏目统计
        int categoryCount = await _categoryRepository.AsQueryable().Where(x => x.Status == AvailabilityStatus.Enable).CountAsync();

        int userCount = await _authAccountRepository.AsQueryable().CountAsync();

        int linkCount = await _friendLinkRepository.AsQueryable().CountAsync(x => x.Status == AvailabilityStatus.Enable);

        return new ArticleReportOutput
        {
            ArticleCount = articleCount,
            CategoryCount = categoryCount,
            TagCount = tagCount,
            LinkCount = linkCount,
            UserCount = userCount
        };
    }

    /// <summary>
    /// 文章详情
    /// </summary>
    /// <param name="id">文章ID</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ArticleInfoOutput> Info([FromQuery] long id)
    {
        long userId = _authManager.UserId;
        var article = await _articleRepository.AsQueryable()
            .LeftJoin<ArticleCategory>((x, ac) => x.Id == ac.ArticleId)
            .InnerJoin<Categories>((x, ac, c) => ac.CategoryId == c.Id && c.Status == AvailabilityStatus.Enable)
            .Where(x => x.Id == id && x.PublishTime <= DateTime.Now && x.Status == AvailabilityStatus.Enable)
            .Where(x => x.ExpiredTime == null || x.ExpiredTime > DateTime.Now)
            .Select((x, ac, c) => new ArticleInfoOutput
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                Summary = x.Summary,
                Cover = x.Cover,
                PublishTime = x.PublishTime,
                Author = x.Author,
                Views = x.Views,
                CreationType = x.CreationType,
                IsAllowComments = x.IsAllowComments,
                IsHtml = x.IsHtml,
                IsTop = x.IsTop,
                Link = x.Link,
                UpdatedTime = x.UpdatedTime,
                CategoryId = c.Id,
                PraiseTotal = SqlFunc.Subqueryable<Praise>().Where(p => p.ObjectId == x.Id).Count(),
                IsPraise = SqlFunc.Subqueryable<Praise>().Where(p => p.ObjectId == x.Id && p.AccountId == userId).Any(),
                CategoryName = c.Name,
                Tags = SqlFunc.Subqueryable<Tags>().InnerJoin<ArticleTag>((tags, at) => tags.Id == at.TagId)
                    .Where((tags, at) => tags.Status == AvailabilityStatus.Enable && at.ArticleId == x.Id)
                    .ToList(tags => new TagsOutput
                    {
                        Id = tags.Id,
                        Name = tags.Name,
                        Color = tags.Color,
                        Icon = tags.Icon
                    })
            }).FirstAsync();
        if (article == null) throw Oops.Bah("糟糕，您访问的信息丢失了...").StatusCode(404);
        await _articleRepository.UpdateAsync(x => new Article()
        {
            Views = x.Views + 1
        }, x => x.Id == article.Id);
        //上一篇
        var prevQuery = _articleRepository.AsQueryable().Where(x => x.PublishTime < article.PublishTime && x.PublishTime <= DateTime.Now && x.Status == AvailabilityStatus.Enable)
            .Where(x => x.ExpiredTime == null || x.ExpiredTime > DateTime.Now)
             .OrderByDescending(x => x.PublishTime)
             .Select(x => new ArticleBasicsOutput { Id = x.Id, Cover = x.Cover, Title = x.Title, PublishTime = null, Type = 0 }).Take(1).MergeTable();
        //下一篇
        var nextQuery = _articleRepository.AsQueryable().Where(x => x.PublishTime > article.PublishTime && x.PublishTime <= DateTime.Now && x.Status == AvailabilityStatus.Enable)
            .Where(x => x.ExpiredTime == null || x.ExpiredTime > DateTime.Now)
                .OrderBy(x => x.PublishTime)
                .Select(x => new ArticleBasicsOutput { Id = x.Id, Cover = x.Cover, Title = x.Title, PublishTime = null, Type = 1 }).Take(1).MergeTable();
        //随机6条
        var randomQuery = _articleRepository.AsQueryable().Where(x => x.Id != id)
            .Where(x => x.PublishTime <= DateTime.Now && x.Status == AvailabilityStatus.Enable)
            .Where(x => x.ExpiredTime == null || x.ExpiredTime > DateTime.Now)
            .OrderBy(x => SqlFunc.GetRandom())
            .Select(x => new ArticleBasicsOutput
            { Id = x.Id, Cover = x.Cover, Title = x.Title, PublishTime = x.PublishTime, Type = 2 })
            .Take(6).MergeTable();
        //相关文章
        var relevant = await _articleRepository.AsSugarClient().Union(prevQuery, nextQuery, randomQuery)
            .OrderBy(x => x.PublishTime).ToListAsync();
        article.Prev = relevant.FirstOrDefault(x => x.Type == 0);
        article.Next = relevant.FirstOrDefault(x => x.Type == 1);
        article.Random = relevant.Where(x => x.Type == 2).ToList();
        article.Views++;
        return article;
    }

    /// <summary>
    /// 最新文章
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<ArticleBasicsOutput>> Latest()
    {
        return await _articleRepository.AsQueryable()
              .Where(x => x.Status == AvailabilityStatus.Enable && x.PublishTime <= DateTime.Now)
              .Where(x => x.ExpiredTime == null || x.ExpiredTime > DateTime.Now)
              .Take(5)
              .OrderByDescending(x => x.Id)
              .Select<ArticleBasicsOutput>()
              .ToListAsync();
    }
}