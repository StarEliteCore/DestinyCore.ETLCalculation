using DestinyCore.ETLCalculation.ETLCore.BlockOptions.BlockInputOptions;
using System.Text;

namespace DestinyCore.ETLCalculation.ETLCore.Extensions
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class BlockDataTableExtension
    {
        /// <summary>
        /// 将输入对象生成Sql语句
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSqlStr(this IBlockDataTableInputOption input)
        {
            var cloumnstr = string.Join(",", input.Column);
            var str = new StringBuilder($"select { cloumnstr} from {input.TableName}");
            return str.ToString();
        }
    }
}
