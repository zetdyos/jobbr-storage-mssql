﻿using System;
using Jobbr.ComponentModel.JobStorage;
using Jobbr.ComponentModel.Registration;

namespace Jobbr.Server.MsSql
{
    public static class JobbrBuilderExtensions
    {
        public static void AddMsSqlStorage(this IJobbrBuilder builder, Action<JobbrMsSqlConfiguration> config)
        {
            var msSqlConfiguration = new JobbrMsSqlConfiguration();

            config(msSqlConfiguration);

            builder.Add<JobbrMsSqlConfiguration>(msSqlConfiguration);

            builder.Register<IJobStorageProvider>(typeof(JobbrMsSqlConfiguration));
            builder.Register<IConfigurationValidator>(typeof(JobbrMsSqlConfigurationValidator));
        }
    }
}