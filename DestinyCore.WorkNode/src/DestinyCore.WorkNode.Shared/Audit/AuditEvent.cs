using DestinyCore.WorkNode.Shared.Events;
using System.Collections.Generic;

namespace DestinyCore.WorkNode.Shared.Audit
{
    public class AuditEvent : EventBase
    {
        public List<AuditEntryInputDto> AuditList { get; set; }
    }
}