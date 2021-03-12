using DestinyCore.ETLDispatchCenter.Domain.Models.DBConnResource;
using DestinyCore.ETLDispatchCenter.Shared;
using DestinyCore.ETLDispatchCenter.Shared.OperationResult;
using System;
using System.Threading.Tasks;

namespace DestinyCore.ETLDispatchCenter.Domain.Services.DBConnResourceDomainService
{
    public class DBConnectionDomainService : IDBConnectionDomainService
    {
        private readonly IAggregateRootRepository<DBConnection, Guid> _dbconnectionRepository = null;

        public DBConnectionDomainService(IAggregateRootRepository<DBConnection, Guid> dbconnectionRepository)
        {
            _dbconnectionRepository = dbconnectionRepository;
        }
        public async Task<OperationResponse> CreateDBConnectionAsync(DBConnection dBConnection)
        {
            return await _dbconnectionRepository.InsertAsync(dBConnection);
        }
        public async Task<OperationResponse> UpdateDBConnectionAsync(DBConnection dBConnection)
        {
            return await _dbconnectionRepository.UpdateAsync(dBConnection);
        }
        public async Task<DBConnection> GetById(Guid id)
        {
            return await _dbconnectionRepository.GetByIdAsync(id);
        }
    }
}
