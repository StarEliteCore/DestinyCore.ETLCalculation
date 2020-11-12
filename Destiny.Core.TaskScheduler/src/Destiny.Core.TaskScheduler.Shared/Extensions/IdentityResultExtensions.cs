using Microsoft.AspNetCore.Identity;
using Destiny.Core.TaskScheduler.Shared.Enums;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using Destiny.Core.TaskScheduler.Shared.ResultMessageConst;
using System.Linq;

namespace Destiny.Core.TaskScheduler.Shared.Extensions
{
    public static partial class Extensions
    {
        public static OperationResponse ToOperationResponse(this IdentityResult identityResult)
        {
            return identityResult.Succeeded ? new OperationResponse(ResultMessage.SaveSusscess, OperationEnumType.Success) : new OperationResponse(identityResult.Errors.Select(o => o.Description).ToJoin(), OperationEnumType.Error);
        }

        public static IdentityResult Failed(this IdentityResult identityResult, params string[] errors)
        {
            var identityErrors = identityResult.Errors;
            identityErrors = identityErrors.Union(errors.Select(m => new IdentityError() { Description = m }));
            return IdentityResult.Failed(identityErrors.ToArray());
        }
    }
}
