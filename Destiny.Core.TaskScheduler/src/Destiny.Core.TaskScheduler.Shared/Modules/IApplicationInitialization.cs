﻿namespace Destiny.Core.TaskScheduler.Shared.Modules
{
    /// <summary>
    /// 应用初始化接口
    /// </summary>
    public interface IApplicationInitialization
    {
        void ApplicationInitialization(ApplicationContext context);
    }
}