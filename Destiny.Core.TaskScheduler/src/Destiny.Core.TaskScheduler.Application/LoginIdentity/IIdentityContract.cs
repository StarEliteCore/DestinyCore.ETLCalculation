using Destiny.Core.TaskScheduler.Dtos.LoginIdentity;
using Destiny.Core.TaskScheduler.Shared;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Application.LoginIdentity
{
    public interface IIdentityContract : IScopedDependency
    {
        Task<(OperationResponse item, Claim[] cliams)> Login(LoginInputDto loginDto);
    }
}