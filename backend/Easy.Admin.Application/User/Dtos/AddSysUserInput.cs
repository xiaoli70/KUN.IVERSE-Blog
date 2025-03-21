﻿namespace Easy.Admin.Application.User.Dtos;

public class AddSysUserInput
{
    /// <summary>
    /// 用户名
    /// </summary>
    [Required(ErrorMessage = "用户名为必填项")]
    [MaxLength(32, ErrorMessage = "用户名限制32个字符内")]
    public string Account { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    [Required(ErrorMessage = "姓名为必填项")]
    [MaxLength(16, ErrorMessage = "姓名限制16个字符内")]
    public string Name { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// 组织机构id
    /// </summary>
    public long OrgId { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [DataValidation(AllowNullValue = true)]
    [MaxLength(32, ErrorMessage = "昵称限制32个字符")]
    public string NickName { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    public DateOnly? Birthday { get; set; }

    /// <summary>
    /// 手机号码
    /// </summary>
    [MaxLength(16, ErrorMessage = "手机号码限制16个字符内")]
    [DataValidation(ValidationTypes.PhoneNumber, ErrorMessage = "手机号码不合法", AllowNullValue = true)]
    public string Mobile { get; set; }

    /// <summary>
    /// 可用状态
    /// </summary>
    public AvailabilityStatus Status { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [MaxLength(64, ErrorMessage = "邮箱限制64个字符内")]
    [DataValidation(ValidationTypes.EmailAddress, ErrorMessage = "邮箱地址不合法", AllowNullValue = true)]
    public string Email { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [MaxLength(200, ErrorMessage = "备注限制200字符内")]
    [DataValidation(AllowNullValue = true)]
    public string Remark { get; set; }

    /// <summary>
    /// 角色
    /// </summary>
    public List<long> Roles { get; set; }
}