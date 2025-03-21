﻿namespace Easy.Admin.Application.Client.Dtos;

public class CategoryOutput
{
    /// <summary>
    /// 栏目ID
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// 父级ID
    /// </summary>
    public long? ParentId { get; set; }
    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; }
    /// <summary>
    /// 栏目名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 文章条数
    /// </summary>
    public int Total { get; set; }
}