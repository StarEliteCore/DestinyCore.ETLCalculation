using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Destiny.Core.TaskScheduler.Domain.Models.IdentityServerFour;
using Destiny.Core.TaskScheduler.Shared;
using System;

namespace Destiny.Core.TaskScheduler.Domain.Models.SuktIdentityServerFour
{
    public class ClientSecretConfiguration : EntityMappingConfiguration<ClientSecret, Guid>
    {
        public override void Map(EntityTypeBuilder<ClientSecret> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ClientSecret");
        }
    }
}