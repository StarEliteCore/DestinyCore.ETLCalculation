using MongoDB.Bson;
using DestinyCore.ETLDataCalculationTransMission.Shared.Entity;
using DestinyCore.ETLDataCalculationTransMission.Shared.Extensions.ResultExtensions;
using DestinyCore.ETLDataCalculationTransMission.Shared.OperationResult;
using System.Threading.Tasks;

namespace DestinyCore.ETLDataCalculationTransMission.Shared.Audit
{
    public interface IAuditStore : IScopedDependency
    {
        Task SaveAudit(AuditChangeInputDto auditLog);
        Task<IPageResult<AuditLogOutputPageDto>> GetAuditLogPageAsync(PageRequest request);
        Task<OperationResponse> GetAuditEntryListByAuditLogIdAsync(ObjectId id);
        Task<OperationResponse> GetAuditEntryListByAuditEntryIdAsync(ObjectId id);
    }
}
