using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLCalculation.Domain.Models.SystemFoundation.DataDictionary;
using DestinyCore.ETLCalculation.Shared;
using DestinyCore.ETLCalculation.Shared.Attributes.Dependency;
using DestinyCore.ETLCalculation.Shared.Entity;
using System;

namespace DestinyCore.ETLCalculation.Domain.Repository.DomainRepository
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