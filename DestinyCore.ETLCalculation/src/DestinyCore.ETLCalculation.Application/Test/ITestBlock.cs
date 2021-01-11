using DestinyCore.ETLCalculation.Shared;

namespace DestinyCore.ETLCalculation.Application.Test
{
    public interface ITestBlock<T> : IScopedDependency
    {
        void Run();
    }
}
