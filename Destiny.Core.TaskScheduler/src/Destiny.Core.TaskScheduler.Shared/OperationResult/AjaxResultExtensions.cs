using Destiny.Core.TaskScheduler.Shared.Enums;
using Destiny.Core.TaskScheduler.Shared.Extensions;

namespace Destiny.Core.TaskScheduler.Shared.OperationResult
{
    public static class AjaxResultExtensions
    {
        public static AjaxResult ToAjaxResult(this OperationResponse operationResponse)
        {
            var message = operationResponse.Message ?? operationResponse.Type.ToDescription();
            AjaxResultType type = operationResponse.Type.ToAjaxResultType();
            return new AjaxResult(message, type, operationResponse.Data) { Success = operationResponse.Success };
        }

        public static AjaxResult ToAjaxResult<T>(this OperationResponse<T> operationResult)
        {
            var message = operationResult.Message ?? operationResult.Type.ToDescription();
            AjaxResultType type = operationResult.Type.ToAjaxResultType();
            return new AjaxResult(message, type, operationResult.Data) { Success = operationResult.Success };
        }

        public static AjaxResultType ToAjaxResultType(this OperationEnumType responseType)
        {
            return responseType switch
            {
                OperationEnumType.Success => AjaxResultType.Success,
                OperationEnumType.NoChanged => AjaxResultType.Info,
                _ => AjaxResultType.Error,
            };
        }
    }
}