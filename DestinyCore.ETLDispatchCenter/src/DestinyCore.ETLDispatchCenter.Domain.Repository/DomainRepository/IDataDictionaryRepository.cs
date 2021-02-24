using Microsoft.Extensions.DependencyInjection;
using DestinyCore.ETLDispatchCenter.Domain.Models.SystemFoundation.DataDictionary;
using DestinyCore.ETLDispatchCenter.Shared;
using DestinyCore.ETLDispatchCenter.Shared.Attributes.Dependency;
using DestinyCore.ETLDispatchCenter.Shared.Entity;
using System;

namespace DestinyCore.ETLDispatchCenter.Domain.Repository.DomainRepository
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