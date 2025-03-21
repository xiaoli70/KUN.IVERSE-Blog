﻿using Easy.Admin.Application.Auth;
using Easy.Admin.Application.Blog.Dtos;

namespace Easy.Admin.Application.Blog;

/// <summary>
/// 相册图片管理
/// </summary>
public class PicturesService : IDynamicApiController
{
    private readonly ISqlSugarRepository<Pictures> _repository;
    private readonly AuthManager _authManager;

    public PicturesService(ISqlSugarRepository<Pictures> repository,
        AuthManager authManager)
    {
        _repository = repository;
        _authManager = authManager;
    }
    /// <summary>
    /// 相册图片分页
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [DisplayName("相册图片分页")]
    [HttpGet]
    [AllowAnonymous]
    public async Task<PageResult<PicturesPageOutput>> Page([FromQuery] PicturesPageQueryInput dto)
    {
        return await _repository.AsQueryable().InnerJoin<Albums>((pictures, albums) => pictures.AlbumId == albums.Id)
            .Where(pictures => pictures.AlbumId == dto.Id)
            .WhereIF(_authManager.AuthPlatformType is null or AuthPlatformType.Blog, (pictures, albums) => albums.IsVisible)
            .Select(pictures => new PicturesPageOutput { Id = pictures.Id, Url = pictures.Url })
            .ToPagedListAsync(dto);
    }

    /// <summary>
    /// 上传图片到相册
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [DisplayName("上传图片到相册")]
    [HttpPost("add")]
    public async Task Add(AddPictureInput dto)
    {
        var list = dto.Adapt<Pictures>();
        await _repository.InsertAsync(list);
    }

    /// <summary>
    /// 删除上册图片
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [DisplayName("删除相册图片")]
    [HttpDelete("delete")]
    public async Task Delete(KeyDto dto)
    {
        await _repository.DeleteAsync(x => x.Id == dto.Id);
    }
}