using DestinyCore.ETLDataCalculationTransMission.Shared.Exceptions;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.Extensions
{
    public class MessageBox
    {
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="message"></param>
        public static void Show(string message) => throw new SuktAppException(message);

        public static void ShowIf(string message, bool flag)
        {

            if (flag)
            {
                throw new SuktAppException(message);
            }
        }
    }
}
