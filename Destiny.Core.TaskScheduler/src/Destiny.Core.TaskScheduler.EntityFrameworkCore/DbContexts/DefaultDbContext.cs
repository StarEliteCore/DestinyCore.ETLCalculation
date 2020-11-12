using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.TaskScheduler.Shared.Audit;
using Destiny.Core.TaskScheduler.Shared.Events.EventBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Shared
{
    public class DefaultDbContext : SuktDbContextBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEventBus _bus;
        private readonly IGetChangeTracker _changeTracker;

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, IServiceProvider serviceProvider)
          : base(options, serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _bus = _serviceProvider.GetService<IEventBus>();
            _changeTracker = _serviceProvider.GetService<IGetChangeTracker>();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var auditlist = await _changeTracker.GetChangeTrackerList(this.ChangeTracker.Entries());
            var result = await base.SaveChangesAsync(cancellationToken);
            //await this.AfterSaveChanges();
            await _bus.PublishAsync(new AuditEvent() { AuditList = auditlist });
            return result;
        }
    }
}