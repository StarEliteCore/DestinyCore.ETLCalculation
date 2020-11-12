using AspectCore.DynamicProxy;
using Destiny.Core.TaskScheduler.Shared.Entity;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Aop.AttributeAOP
{
    /// <summary>
    /// 特性代理AOP事务；在需要使用的方法上配置次特性就好
    /// </summary>
    public class NonGlobalAopTranAttribute : AbstractInterceptorAttribute
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            _unitOfWork = context.ServiceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            _unitOfWork.BeginTransaction();
            Console.WriteLine("代理方法执行前");
            await next(context);
            Console.WriteLine("代理方法执行后");
            _unitOfWork.Commit();
        }
    }
}