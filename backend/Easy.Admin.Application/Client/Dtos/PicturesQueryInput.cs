﻿namespace Easy.Admin.Application.Client.Dtos;

public class PicturesQueryInput : Pagination
{
    /// <summary>
    /// 相册ID
    /// </summary>
    public long AlbumId { get; set; }
}