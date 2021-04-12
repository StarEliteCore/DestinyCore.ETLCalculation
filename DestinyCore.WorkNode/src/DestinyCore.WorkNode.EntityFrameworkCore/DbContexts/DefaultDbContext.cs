using Microsoft.EntityFrameworkCore;
using System;

namespace DestinyCore.WorkNode.Shared
{
    public class DefaultDbContext : SuktDbContextBase
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, IServiceProvider serviceProvider)
          : base(options, serviceProvider)
        {
        }
    }
}
