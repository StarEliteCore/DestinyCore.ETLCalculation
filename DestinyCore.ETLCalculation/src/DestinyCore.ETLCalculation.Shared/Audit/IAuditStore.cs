using MongoDB.Bson;
using DestinyCore.ETLCalculation.Shared.Entity;
using DestinyCore.ETLCalculation.Shared.Extensions.ResultExtensions;
using DestinyCore.ETLCalculation.Shared.OperationResult;
using System.Threading.Tasks;

namespace DestinyCore.ETLCalculation.Shared.Audit
{
    public interface IAuditStore : IScopedDependency
    {
        Task SaveAudit(AuditChangeInputDto auditLog);
        Task<IPageResult<AuditLogOutputPageDto>> GetAuditLogPageAsync(PageRequest request);
        Task<OperationResponse> GetAuditEntryListByAuditLogIdAsync(ObjectId id);
        Task<OperationResponse> GetAuditEntryListByAuditEntryIdAsync(ObjectId id);
    }
}
