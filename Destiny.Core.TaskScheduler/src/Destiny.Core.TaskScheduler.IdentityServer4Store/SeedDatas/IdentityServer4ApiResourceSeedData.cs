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
    public class IdentityServer4ApiResourceSeedData : SeedDataDefaults<ApiResource, Guid>
    {
        public IdentityServer4ApiResourceSeedData(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override Expression<Func<ApiResource, bool>> Expression(ApiResource entity)
        {
            return o => o.Name == entity.Name;
        }

        protected override ApiResource[] SetSeedData()
        {
            List<ApiResource> apiResources = new List<ApiResource>();
            foreach (var item in Config.GetApiResources())
            {
                var model = item.MapTo<ApiResource>();
                model.CreatedAt = DateTime.Now;
                model.CreatedId = Guid.Parse("c5604f31-f14c-e8be-0833-9c69b2a8eba2");
                model.IsDeleted = false;
                apiResources.Add(model);
            }
            return apiResources.ToArray();
        }
    }
}