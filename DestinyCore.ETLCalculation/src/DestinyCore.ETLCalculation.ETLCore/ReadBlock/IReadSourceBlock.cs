using DestinyCore.ETLCalculation.Shared;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore.ReadBlock
{
    public interface IReadSourceBlock<TOutPut> : ISourceBlock<TOutPut>, IScopedDependency
    {
        ISourceBlock<TOutPut> GetData();
    }
}
