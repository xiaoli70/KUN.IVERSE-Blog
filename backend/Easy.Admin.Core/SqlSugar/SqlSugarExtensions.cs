﻿using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using Easy.Admin.Core.Const;
using Easy.Admin.Core.Entities;
using Easy.Admin.Core.Enum;
using Easy.Admin.Core.Options;
using Mapster;
using Newtonsoft.Json;
using Yitter.IdGenerator;

namespace SqlSugar;

public static class SqlSugarExtensions
{
    /// <summary>
    /// 添加 SqlSugar 拓展（适用于单个数据库）
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config">数据库连接对象</param>
    /// <param name="buildAction"></param>
    /// <returns></returns>
    public static IServiceCollection AddSqlSugar(this IServiceCollection services, ConnectionConfigExt config, Action<ISqlSugarClient> buildAction = default)
    {
        return services.AddSqlSugar(new List<ConnectionConfigExt>()
        {
            config
        }, buildAction);
    }

    /// <summary>
    /// 添加 SqlSugar 拓展（适用于多数据库）
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configs">数据库连接对象集合</param>
    /// <param name="buildAction"></param>
    /// <returns></returns>
    public static IServiceCollection AddSqlSugar(this IServiceCollection services, List<ConnectionConfigExt> configs, Action<SqlSugarClient> buildAction = default)
    {
        SqlSugarScope sqlSugarScope = new SqlSugarScope(configs.Adapt<List<ConnectionConfig>>(), buildAction ?? Aop);
        configs.ForEach(x =>
        {
            Init(sqlSugarScope, x);
        });
        services.AddSingleton<ISqlSugarClient>(sqlSugarScope);//使用单例注入
        services.AddSingleton<ITenant>(sqlSugarScope);
        services.AddUnitOfWork<SqlSugarUnitOfWork>();//事务
        services.AddScoped(typeof(ISqlSugarRepository<>), typeof(SqlSugarRepository<>));//注入泛型仓储

        return services;
    }

    /// <summary>
    /// 初始化数据库
    /// </summary>
    /// <param name="client"></param>
    /// <param name="config"></param>
    static void Init(SqlSugarScope client, ConnectionConfigExt config)
    {
        if (!config.EnableInitDb)
        {
            return;
        }
        SqlSugarScopeProvider provider = client.GetConnectionScope(config.ConfigId);
        //创建数据库
        provider.DbMaintenance.CreateDatabase();
        IEnumerable<Type> types = App.EffectiveTypes.Where(x => !x.IsInterface && x.IsClass && !x.IsAbstract && typeof(IEntity).IsAssignableFrom(x));
        provider.CodeFirst.InitTables(types.ToArray());

        //初始化数据
        InitData(client);
    }

    /// <summary>
    /// 添加 SqlSugar 服务
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSqlSugar(this IServiceCollection services)
    {
        var options = App.GetOptions<DbConnectionOptions>();
        ICacheService ormCache = new SqlSugarCache();
        options.Connections.ForEach(x =>
        {
            x.MoreSettings = new ConnMoreSettings()
            {
                //所有 增、删 、改 会自动调用.RemoveDataCache()
                IsAutoRemoveDataCache = true
            };
            //配置缓存
            x.ConfigureExternalServices = new ConfigureExternalServices()
            {
                DataInfoCacheService = ormCache,
                EntityService = ((prop, column) =>
                {
                    //如果实体不是主键，并且是可空类型，表列设置为可空(支持string?和string)
                    if (column.IsPrimarykey == false && new NullabilityInfoContext()
                            .Create(prop).WriteState is NullabilityState.Nullable)
                    {
                        column.IsNullable = true;
                    }
                })

            };

        });
        return AddSqlSugar(services, options.Connections, Aop);
    }

    /// <summary>
    /// 拦截器
    /// </summary>
    private static readonly Action<SqlSugarClient> Aop = (db) =>
    {
        db.Aop.DataExecuting = (_, entityInfo) =>
        {
            switch (entityInfo.OperationType)
            {
                //执行insert时
                case DataFilterType.InsertByObject:
                    //自动设置主键
                    if (entityInfo.EntityColumnInfo.IsPrimarykey &&
                        entityInfo.EntityValue is Entity<long> { Id: 0 } entity)
                    {
                        entity.Id = YitIdHelper.NextId();
                    }
                    //如果当前实体继承ICreatedTime就设置创建时间
                    if (entityInfo.EntityValue is ICreatedTime createdTime && createdTime.CreatedTime == DateTime.MinValue)
                    {
                        createdTime.CreatedTime = DateTime.Now;
                    }
                    if (entityInfo.EntityValue is ICreatedUserId { CreatedUserId: 0 } createdUserId)
                    {
                        createdUserId.CreatedUserId = App.User.FindFirst(AuthClaimsConst.AuthIdKey)!.Value.Adapt<long>();
                    }
                    break;
                case DataFilterType.UpdateByObject:
                    if (entityInfo.EntityValue is IUpdatedTime updatedTime)
                    {
                        updatedTime.UpdatedTime = DateTime.Now;
                    }

                    break;
                case DataFilterType.DeleteByObject:
                    break;
            }
        };

        // 文档地址：https://www.donet5.com/Home/Doc?typeId=1204
        db.Aop.OnLogExecuting = (sql, parameters) =>
        {
            var originColor = Console.ForegroundColor;
            if (sql.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                Console.ForegroundColor = ConsoleColor.Green;
            if (sql.StartsWith("UPDATE", StringComparison.OrdinalIgnoreCase) || sql.StartsWith("INSERT", StringComparison.OrdinalIgnoreCase))
                Console.ForegroundColor = ConsoleColor.Yellow;
            if (sql.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase))
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("【" + DateTime.Now + "——执行SQL】\r\n" + UtilMethods.GetSqlString(db.CurrentConnectionConfig.DbType, sql, parameters) + "\r\n");
            Console.ForegroundColor = originColor;
            App.PrintToMiniProfiler("SqlSugar", "Info", sql + "\r\n" + db.Utilities.SerializeObject(parameters.ToDictionary(it => it.ParameterName, it => it.Value)));
        };
        db.Aop.OnError = ex =>
        {
            if (ex.Parametres == null) return;
            var originColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            var pars = db.Utilities.SerializeObject(((SugarParameter[])ex.Parametres).ToDictionary(it => it.ParameterName, it => it.Value));
            Console.WriteLine("【" + DateTime.Now + "——错误SQL】\r\n" + UtilMethods.GetSqlString(db.CurrentConnectionConfig.DbType, ex.Sql, (SugarParameter[])ex.Parametres) + "\r\n");
            Console.ForegroundColor = originColor;
            App.PrintToMiniProfiler("SqlSugar", "Error", $"{ex.Message}{Environment.NewLine}{ex.Sql}{pars}{Environment.NewLine}");
        };

        //配置逻辑删除过滤器（查询数据时过滤掉已被标记删除的数据）
        db.QueryFilter.AddTableFilter<ISoftDelete>(it => it.DeleteMark == false);
    };

    /// <summary>
    /// 初始化基础数据
    /// </summary>
    private static void InitData(SqlSugarScope client)
    {
        List<SysUser> users = new List<SysUser>()
        {
            new SysUser()
            {
                Id = 1,
                Account = "admin",
                Password = "9658b68df5e6208e97ae6c8f4eac6c39",
                Name = "管理员",
                Gender = Gender.Female,
                NickName = "管理员",
                Avatar = "https://oss.okay123.top/oss//2023/07/13/Yln0lzZQLN.jpg",
                CreatedUserId = 1
            },
            new SysUser()
            {
                Id = 50048753934341,
                Account = "test",
                Password = "65caa9533b8d9f336bd07919dd9bf74e",
                Name = "测试",
                Gender = Gender.Female,
                NickName = "测试",
                CreatedUserId = 1
            }
        };
        client.Storageable(users).ToStorage().AsInsertable.ExecuteCommand();

        string path = Path.Combine(AppContext.BaseDirectory, "InitData");
        var dir = new DirectoryInfo(path);
        var files = dir.GetFiles("*.txt");
        foreach (var file in files)
        {
            using var reader = file.OpenText();
            string s = reader.ReadToEnd();
            var table = JsonConvert.DeserializeObject<DataTable>(s);
            if (table.Rows.Count == 0)
            {
                continue;
            }
            table.TableName = file.Name.Replace(".txt", "");

            client.Storageable(table).WhereColumns("Id").ToStorage().AsInsertable.ExecuteCommand();
        }
    }
}