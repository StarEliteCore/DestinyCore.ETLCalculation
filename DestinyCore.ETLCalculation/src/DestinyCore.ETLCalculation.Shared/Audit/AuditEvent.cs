using DestinyCore.ETLCalculation.Shared.Events;
using System.Collections.Generic;

namespace DestinyCore.ETLCalculation.Shared.Audit
{
    public class AuditEvent : EventBase
    {
        public List<AuditEntryInputDto> AuditList { get; set; }
    }
}