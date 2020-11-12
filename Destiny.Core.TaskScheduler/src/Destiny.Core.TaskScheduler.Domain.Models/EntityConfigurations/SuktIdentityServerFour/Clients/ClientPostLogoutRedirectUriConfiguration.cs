using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.TaskScheduler.Domain.Models.IdentityServerFour;
using Destiny.Core.TaskScheduler.Shared;
using System;

namespace Destiny.Core.TaskScheduler.Domain.Models.SuktIdentityServerFour
{
    public class ClientPostLogoutRedirectUriConfiguration : EntityMappingConfiguration<ClientPostLogoutRedirectUri, Guid>
    {
        public override void Map(EntityTypeBuilder<ClientPostLogoutRedirectUri> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ClientPostLogoutRedirectUri");
        }
    }
}