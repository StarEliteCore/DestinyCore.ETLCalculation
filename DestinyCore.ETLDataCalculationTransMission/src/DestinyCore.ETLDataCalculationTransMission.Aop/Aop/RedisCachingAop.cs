using AspectCore.DynamicProxy;
using System.Threading.Tasks;

namespace DestinyCore.ETLDataCalculationTransMission.Aop.Aop
{
    public class RedisCachingAop : AbstractInterceptor
    {
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            await next(context);
        }
    }
}