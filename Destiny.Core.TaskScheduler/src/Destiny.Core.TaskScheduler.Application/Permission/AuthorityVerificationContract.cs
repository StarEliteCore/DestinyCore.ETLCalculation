using Destiny.Core.TaskScheduler.Shared.Permission;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Application.Permission
{
    public class AuthorityVerificationContract : IAuthorityVerification
    {
        public Task<bool> IsPermission(string url)
        {
            //throw new NotImplementedException();
            return Task.FromResult(true);
        }
    }
}