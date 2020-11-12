using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.TaskScheduler.Domain.Models.SystemFoundation.DataDictionary;
using Destiny.Core.TaskScheduler.Shared;
using Destiny.Core.TaskScheduler.Shared.Attributes.Dependency;
using Destiny.Core.TaskScheduler.Shared.Entity;
using System;

namespace Destiny.Core.TaskScheduler.Domain.Repository.DomainRepository
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