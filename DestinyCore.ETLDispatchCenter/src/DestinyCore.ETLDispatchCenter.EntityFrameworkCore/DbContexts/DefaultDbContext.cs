using Microsoft.EntityFrameworkCore;
using System;

namespace DestinyCore.ETLDispatchCenter.Shared
{
    public class DefaultDbContext : SuktDbContextBase
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, IServiceProvider serviceProvider)
          : base(options, serviceProvider)
        {
        }
    }
}
