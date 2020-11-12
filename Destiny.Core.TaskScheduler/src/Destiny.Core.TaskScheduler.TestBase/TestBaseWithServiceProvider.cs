﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace Destiny.Core.TaskScheduler.TestBase
{
    public abstract class TestBaseWithServiceProvider
    {
        protected abstract IServiceProvider ServiceProvider { get; }

        protected virtual T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        protected virtual T GetRequiredService<T>()
        {
            return ServiceProvider.GetRequiredService<T>();
        }
    }
}