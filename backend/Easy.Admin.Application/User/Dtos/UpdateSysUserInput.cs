﻿namespace Easy.Admin.Application.User.Dtos;

public class UpdateSysUserInput : AddSysUserInput
{
    /// <summary>
    /// 用户Id
    /// </summary>
    public long Id { get; set; }
}