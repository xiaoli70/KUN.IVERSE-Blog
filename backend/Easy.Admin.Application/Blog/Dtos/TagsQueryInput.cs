﻿namespace Easy.Admin.Application.Blog.Dtos;

public class TagsPageQueryInput : Pagination
{
    /// <summary>
    /// 标签名称 
    /// </summary>
    public string Name { get; set; }
}