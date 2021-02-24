namespace DestinyCore.ETLDispatchCenter.MongoDB.Infrastructure
{
    public interface IMongoDbContextOptions
    {
        string ConnectionString { get; set; }
    }
}