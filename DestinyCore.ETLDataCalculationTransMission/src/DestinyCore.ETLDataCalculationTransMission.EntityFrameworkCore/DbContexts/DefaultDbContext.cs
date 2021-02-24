using Microsoft.EntityFrameworkCore;
using System;

namespace DestinyCore.ETLDataCalculationTransMission.Shared
{
    public class DefaultDbContext : SuktDbContextBase
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, IServiceProvider serviceProvider)
          : base(options, serviceProvider)
        {
        }
    }
}
