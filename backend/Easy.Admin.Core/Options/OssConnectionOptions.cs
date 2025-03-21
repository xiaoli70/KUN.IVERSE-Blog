﻿using Furion.ConfigurableOptions;
using OnceMi.AspNetCore.OSS;

namespace Easy.Admin.Core.Options;
/// <summary>
/// 对象存储连接配置
/// </summary>
public sealed class OssConnectionOptions : OSSOptions, IConfigurableOptions
{
    /// <summary>
    /// 默认存目录
    /// </summary>
    public string Bucket { get; set; }

    /// <summary>
    /// 外网访问域名或IP
    /// </summary>
    public string Domain { get; set; }

    /// <summary>
    /// 是否启用对象存储（不启用将存储至站点目录）
    /// </summary>
    public bool Enable { get; set; }
}