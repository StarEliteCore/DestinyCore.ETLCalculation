using Destiny.Core.TaskScheduler.Domain.Models;
using Destiny.Core.TaskScheduler.Identity;
using Destiny.Core.TaskScheduler.Shared.Entity;
using System;

namespace Destiny.Core.TaskScheduler.Domain.Repository
{
    public class UserStore : UserStoreBase<UserEntity, Guid, UserClaimEntity, UserLoginEntity, UserTokenEntity, RoleEntity, Guid, UserRoleEntity>
    {
        public UserStore(
            IEFCoreRepository<UserEntity, Guid> userRepository,
            IEFCoreRepository<UserLoginEntity, Guid> userLoginRepository,
            IEFCoreRepository<UserClaimEntity, Guid> userClaimRepository,
            IEFCoreRepository<UserTokenEntity, Guid> userTokenRepository,
            IEFCoreRepository<RoleEntity, Guid> roleRepository,
            IEFCoreRepository<UserRoleEntity, Guid> userRoleRepository)
            : base(userRepository, userLoginRepository, userClaimRepository, userTokenRepository, roleRepository, userRoleRepository)
        {
        }
    }
}