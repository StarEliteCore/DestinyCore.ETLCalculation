using Microsoft.AspNetCore.Identity;
using DestinyCore.ETLDispatchCenter.Shared.Enums;
using DestinyCore.ETLDispatchCenter.Shared.OperationResult;
using DestinyCore.ETLDispatchCenter.Shared.ResultMessageConst;
using System.Linq;

namespace DestinyCore.ETLDispatchCenter.Shared.Extensions
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
