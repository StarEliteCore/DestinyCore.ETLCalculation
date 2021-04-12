namespace DestinyCore.WorkNode.MongoDB.Infrastructure
{
    public interface IMongoDbContextOptions
    {
        string ConnectionString { get; set; }
    }
}