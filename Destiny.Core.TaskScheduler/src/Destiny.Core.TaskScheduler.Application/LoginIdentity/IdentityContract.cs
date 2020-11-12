using Microsoft.AspNetCore.Identity;
using Destiny.Core.TaskScheduler.Domain.Models;
using Destiny.Core.TaskScheduler.Dtos.LoginIdentity;
using Destiny.Core.TaskScheduler.Shared.Enums;
using Destiny.Core.TaskScheduler.Shared.Extensions;
using Destiny.Core.TaskScheduler.Shared.OperationResult;
using Destiny.Core.TaskScheduler.Shared.ResultMessageConst;
using Destiny.Core.TaskScheduler.Shared.Security.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Application.LoginIdentity
{
    public class IdentityContract : IIdentityContract
    {
        private readonly SignInManager<UserEntity> _signInManager = null;
        private readonly UserManager<UserEntity> _userManager = null;
        private readonly IJwtBearerService _jwtBearerService = null;

        public IdentityContract(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, IJwtBearerService jwtBearerService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtBearerService = jwtBearerService;
        }

        public async Task<(OperationResponse item, Claim[] cliams)> Login(LoginInputDto input)
        {
            input.NotNull(nameof(input));
            var user = await _userManager.FindByNameAsync(input.UserName);
            if (user == null)
                return (new OperationResponse(ResultMessage.UserNameNotFind, OperationEnumType.Error), new Claim[] { });
            var result = await _userManager.CheckPasswordAsync(user, input.Password);
            if (!result)
                return (new OperationResponse(ResultMessage.PassWordNotCheck, OperationEnumType.Error), new Claim[] { });
            var jwtToken = _jwtBearerService.CreateToken(user.Id, user.UserName);

            return (new OperationResponse(ResultMessage.LoginSusscess, new
            {
                AccessToken = jwtToken.AccessToken,
                NickName = user.NickName,
                UserId = user.Id.ToString(),
                AccessExpires = jwtToken.AccessExpires
            }, OperationEnumType.Error), new Claim[] { });
        }
    }
}