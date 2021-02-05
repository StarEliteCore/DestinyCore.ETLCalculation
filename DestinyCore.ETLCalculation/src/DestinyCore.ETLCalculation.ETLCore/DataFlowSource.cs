using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore
{
    public abstract class DataFlowSource<TOutput> : IDataFlowSource<TOutput>
    {
        public abstract ISourceBlock<TOutput> SourceBlock { get; }

    }
}
