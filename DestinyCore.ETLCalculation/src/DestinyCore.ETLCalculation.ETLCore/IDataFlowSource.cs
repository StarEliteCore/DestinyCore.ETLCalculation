using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore
{
    public interface IDataFlowSource<TOutput>
    {
        ISourceBlock<TOutput> SourceBlock { get; }
    }
}
