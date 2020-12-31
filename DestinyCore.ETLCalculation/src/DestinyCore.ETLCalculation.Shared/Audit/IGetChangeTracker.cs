using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.Shared.Audit
{
    public interface IGetChangeTracker : IScopedDependency
    {
        List<AuditEntryInputDto> GetChangeTrackerList(IEnumerable<EntityEntry> Entries);
    }
}
