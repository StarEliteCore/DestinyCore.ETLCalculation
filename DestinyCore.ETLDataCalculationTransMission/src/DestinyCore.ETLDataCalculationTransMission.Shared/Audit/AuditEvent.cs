using DestinyCore.ETLDataCalculationTransMission.Shared.Events;
using System.Collections.Generic;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.Audit
{
    public class AuditEvent : EventBase
    {
        public List<AuditEntryInputDto> AuditList { get; set; }
    }
}