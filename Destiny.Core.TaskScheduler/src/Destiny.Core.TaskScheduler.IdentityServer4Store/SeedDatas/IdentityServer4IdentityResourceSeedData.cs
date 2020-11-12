using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.TaskScheduler.Domain.Models.IdentityServerFour;
using Destiny.Core.TaskScheduler.Domain.Models.SeedDatas;
using Destiny.Core.TaskScheduler.Shared.Attributes.Dependency;
using Destiny.Core.TaskScheduler.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Destiny.Core.TaskScheduler.IdentityServer4Store
{
    [Dependency(ServiceLifetime.Singleton)]
    public class IdentityServer4IdentityResourceSeedData : SeedDataDefaults<IdentityResource, Guid>
    {
        public IdentityServer4IdentityResourceSeedData(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override Expression<Func<IdentityResource, bool>> Expression(IdentityResource entity)
        {
            return o => o.Name == entity.Name;
        }

        protected override IdentityResource[] SetSeedData()
        {
            List<IdentityResource> identityResources = new List<IdentityResource>();
            foreach (var item in Config.GetIdentityResources())
            {
                var model = item.MapTo<IdentityResource>();
                model.CreatedAt = DateTime.Now;
                model.CreatedId = Guid.Parse("c5604f31-f14c-e8be-0833-9c69b2a8eba2");
                model.IsDeleted = false;
                identityResources.Add(model);
            }
            return identityResources.ToArray();
        }
    }
}