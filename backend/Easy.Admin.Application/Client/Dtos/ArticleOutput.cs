﻿namespace Easy.Admin.Application.Client.Dtos;

public class ArticleOutput
{
    /// <summary>
    /// 文章ID
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// 栏目ID
    /// </summary>
    public long CategoryId { get; set; }
    /// <summary>
    /// 栏目名称
    /// </summary>
    public string CategoryName { get; set; }
    /// <summary>
    /// 是否置顶
    /// </summary>
    public bool IsTop { get; set; }
    /// <summary>
    /// 创作类型
    /// </summary>
    public CreationType CreationType { get; set; }
    /// <summary>
    /// 简介
    /// </summary>
    public string Summary { get; set; }
    /// <summary>
    /// 封面图
    /// </summary>
    public string Cover { get; set; }
    /// <summary>
    /// 发布时间
    /// </summary>
    public DateTime PublishTime { get; set; }
    /// <summary>
    /// 标签
    /// </summary>
    public List<TagsOutput> Tags { get; set; }
}