namespace Destiny.Core.TaskScheduler.MongoDB.Infrastructure
{
    public interface IMongoDbContextOptions
    {
        string ConnectionString { get; set; }
    }
}