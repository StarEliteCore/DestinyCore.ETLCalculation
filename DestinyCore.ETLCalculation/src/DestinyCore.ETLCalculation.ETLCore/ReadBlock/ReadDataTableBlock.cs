using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore.ReadBlock
{
    public class ReadDataTableBlock<TOutPut> : IReadSourceBlock<TOutPut>
    {
        public Task Completion => throw new NotImplementedException();

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public TOutPut ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutPut> target, out bool messageConsumed)
        {
            throw new NotImplementedException();
        }

        public void Fault(Exception exception)
        {
            throw new NotImplementedException();
        }

        public ISourceBlock<TOutPut> GetData()
        {
            throw new NotImplementedException();
        }

        public IDisposable LinkTo(ITargetBlock<TOutPut> target, DataflowLinkOptions linkOptions)
        {
            throw new NotImplementedException();
        }

        public void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TOutPut> target)
        {
            throw new NotImplementedException();
        }

        public bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutPut> target)
        {
            throw new NotImplementedException();
        }
    }
}
