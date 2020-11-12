using Destiny.Core.TaskScheduler.Domain.Models;
using Destiny.Core.TaskScheduler.Identity;
using Destiny.Core.TaskScheduler.Shared.Entity;
using System;

namespace Destiny.Core.TaskScheduler.Domain.Repository
{
    public class RoleStore : RoleStoreBase<RoleEntity, Guid, RoleClaimEntity>
    {
        public RoleStore(IEFCoreRepository<RoleEntity, Guid> roleRepository, IEFCoreRepository<RoleClaimEntity, Guid> roleClaimRepository)
            : base(roleRepository, roleClaimRepository)
        { }
    }
}