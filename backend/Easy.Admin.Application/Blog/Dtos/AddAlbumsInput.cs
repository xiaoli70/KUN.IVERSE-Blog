﻿namespace Easy.Admin.Application.Blog.Dtos;

public class AddAlbumsInput
{
    /// <summary>
    /// 相册名称
    /// </summary>
    [Required(ErrorMessage = "相册名称为必填项")]
    [MaxLength(32, ErrorMessage = "相册名称限制32个字符")]
    public string Name { get; set; }

    /// <summary>
    /// 封面图
    /// </summary>
    [Required(ErrorMessage = "请上传相册封面")]
    [MaxLength(256)]
    public string Cover { get; set; }

    /// <summary>
    /// 相册类型
    /// </summary>
    public CoverType? Type { get; set; }

    /// <summary>
    /// 可用状态
    /// </summary>
    public AvailabilityStatus Status { get; set; }

    /// <summary>
    /// 排序值（值越小越靠前）
    /// </summary>
    [Required(ErrorMessage = "排序值为必填项")]
    public int Sort { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [MaxLength(200, ErrorMessage = "备注限制200个字符内")]
    public string Remark { get; set; }

    /// <summary>
    /// 是否可见
    /// </summary>
    public bool IsVisible { get; set; }
}