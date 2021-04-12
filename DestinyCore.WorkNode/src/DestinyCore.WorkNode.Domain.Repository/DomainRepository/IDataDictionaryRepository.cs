using Microsoft.Extensions.DependencyInjection;
using DestinyCore.WorkNode.Domain.Models.SystemFoundation.DataDictionary;
using DestinyCore.WorkNode.Shared;
using DestinyCore.WorkNode.Shared.Attributes.Dependency;
using DestinyCore.WorkNode.Shared.Entity;
using System;

namespace DestinyCore.WorkNode.Domain.Repository.DomainRepository
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