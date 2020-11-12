using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.TaskScheduler.Shared.Audit
{
    public interface IGetChangeTracker : IScopedDependency
    {
        Task<List<AuditEntryInputDto>> GetChangeTrackerList(IEnumerable<EntityEntry> Entries);
    }
}