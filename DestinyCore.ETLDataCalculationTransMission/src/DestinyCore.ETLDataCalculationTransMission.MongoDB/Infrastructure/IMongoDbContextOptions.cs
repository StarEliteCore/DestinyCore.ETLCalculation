namespace DestinyCore.ETLDataCalculationTransMission.MongoDB.Infrastructure
{
    public interface IMongoDbContextOptions
    {
        string ConnectionString { get; set; }
    }
}