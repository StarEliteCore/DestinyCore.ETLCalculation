using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace DestinyCore.WorkNode.Shared.Audit
{
    public interface IGetChangeTracker : IScopedDependency
    {
        List<AuditEntryInputDto> GetChangeTrackerList(IEnumerable<EntityEntry> Entries);
    }
}
