﻿using Easy.Admin.Core.Enum;

namespace Easy.Admin.Core.Entities;
/// <summary>
/// 文章表
/// </summary>
public class Article : Entity<long>, IAvailability, ISortable, ISoftDelete, IUpdatedTime, ICreatedUserId, ICreatedTime
{
    /// <summary>
    /// 标题
    /// </summary>
    [SugarColumn(Length = 128)]
    public string Title { get; set; }

    /// <summary>
    /// 概要
    /// </summary>
    [SugarColumn(Length = 256)]
    public string Summary { get; set; }

    /// <summary>
    /// 封面图
    /// </summary>
    [SugarColumn(Length = 256)]
    public string Cover { get; set; }

    /// <summary>
    /// 是否置顶
    /// </summary>
    public bool IsTop { get; set; }

    /// <summary>
    /// 浏览量
    /// </summary>
    public int Views { get; set; }

    /// <summary>
    /// 作者
    /// </summary>
    [SugarColumn(Length = 32)]
    public string Author { get; set; }

    /// <summary>
    /// 原文地址
    /// </summary>
    [SugarColumn(Length = 256)]
    public string? Link { get; set; }

    /// <summary>
    /// 创作类型
    /// </summary>
    public CreationType CreationType { get; set; }

    /// <summary>
    /// 文章正文（Html或markdown）
    /// </summary>
    [SugarColumn(ColumnDataType = "text")]
    public string Content { get; set; }

    /// <summary>
    /// 文章正文是否为html代码
    /// </summary>
    public bool IsHtml { get; set; }

    /// <summary>
    /// 发布时间
    /// </summary>
    public DateTime PublishTime { get; set; }

    /// <summary>
    /// 可用状态
    /// </summary>
    public AvailabilityStatus Status { get; set; }

    /// <summary>
    /// 排序值（值越小越靠前）
    /// </summary>
    public int Sort { get; set; }

    /// <summary>
    /// 是否允许评论
    /// </summary>
    public bool IsAllowComments { get; set; }

    /// <summary>
    /// 过期时间（过期后文章不显示）
    /// </summary>
    public DateTime? ExpiredTime { get; set; }

    /// <summary>
    /// 标记删除
    /// </summary>
    public bool DeleteMark { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdatedTime { get; set; }

    /// <summary>
    /// 创建人
    /// </summary>
    public long CreatedUserId { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }
}