﻿namespace Easy.Admin.Application.Blog.Dtos;

public class UpdateCategoryInput : AddCategoryInput
{
    /// <summary>
    /// 栏目ID
    /// </summary>
    [Required(ErrorMessage = "缺少必要参数")]
    public long Id { get; set; }
}