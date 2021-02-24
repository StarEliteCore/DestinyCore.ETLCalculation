using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLDataCalculationTransMission.Domain.Models.SystemFoundation.DataDictionary;
using DestinyCore.ETLDataCalculationTransMission.Shared;
using DestinyCore.ETLDataCalculationTransMission.Shared.Attributes.Dependency;
using DestinyCore.ETLDataCalculationTransMission.Shared.Entity;
using System;

namespace DestinyCore.ETLDataCalculationTransMission.Domain.Repository.DomainRepository
{
    public interface IDataDictionaryRepository : IEFCoreRepository<DataDictionaryEntity, Guid>
    {
    }

    [Dependency(ServiceLifetime.Scoped)]
    public class DataDictionaryRepository : BaseRepository<DataDictionaryEntity, Guid>, IDataDictionaryRepository
    {
        public DataDictionaryRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}