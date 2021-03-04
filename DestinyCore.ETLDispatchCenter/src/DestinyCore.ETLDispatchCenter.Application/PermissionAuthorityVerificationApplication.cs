using DestinyCore.ETLDispatchCenter.Shared.Permission;
using System.Threading.Tasks;

namespace DestinyCore.ETLDispatchCenter.Application
{
    public class PermissionAuthorityVerificationApplication : IAuthorityVerification
    {
        public Task<bool> IsPermission(string url)
        {
            return Task.FromResult(true);
        }
    }
}
