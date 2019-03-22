﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.EntityFramework;
using System;

namespace Startup.Base
{
    public abstract class StartupBase : IStartupEF
    {
        private IStartupEF _startupEf = null;

        public StartupBase(string connectionStringName = "")
        {
            if (connectionStringName != "")
            {
                _startupEf = new StartupEf(Configuration, connectionStringName); 
            }
        }

        public IConfiguration Configuration { get; protected set; }

        public void ConfigureServices(IServiceCollection services)
        {
            if (_startupEf != null)
            {
                _startupEf.ConfigureServices(services); 
            }
        }
    }
}
