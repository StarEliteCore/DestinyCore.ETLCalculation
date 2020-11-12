using Destiny.Core.TaskScheduler.Shared.Events;
using System.Collections.Generic;

namespace Destiny.Core.TaskScheduler.Shared.Audit
{
    public class AuditEvent : EventBase
    {
        public List<AuditEntryInputDto> AuditList { get; set; }
    }
}