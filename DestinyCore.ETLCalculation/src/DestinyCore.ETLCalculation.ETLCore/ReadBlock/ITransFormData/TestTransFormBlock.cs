using DestinyCore.ETLCalculation.ETLCore.BlockOutput;
using DestinyCore.ETLCalculation.ETLCore.ReadBlock.CleanData;
using System.Threading.Tasks.Dataflow;

namespace DestinyCore.ETLCalculation.ETLCore.ReadBlock.ITransFormData
{
    public class TestTransFormBlock : ITransFormBlock
    {
        public IPropagatorBlock<IBlockOutputOption, IBlockOutputOption> TransForm()
        {
            return new TransformBlock<IBlockOutputOption, IBlockOutputOption>(input =>
            {
                input.Data.Add("王爸爸", "as4d135as1d23as1da3sd13asd13as");
                System.Console.WriteLine("数据转换");
                return input;
            });
        }
    }
}
