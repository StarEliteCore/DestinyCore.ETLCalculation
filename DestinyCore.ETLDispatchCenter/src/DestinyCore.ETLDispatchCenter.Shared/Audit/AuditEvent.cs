using DestinyCore.ETLDispatchCenter.Shared.Events;
using System.Collections.Generic;

namespace DestinyCore.ETLDispatchCenter.Shared.Audit
{
    public class AuditEvent : EventBase
    {
        public List<AuditEntryInputDto> AuditList { get; set; }
    }
}