using MongoDB.Bson;
using DestinyCore.ETLDataCalculationTransMission.Shared.Entity;

namespace DestinyCore.ETLDataCalculationTransMission.MongoDB
{
    public abstract class MongoEntity : IEntity<ObjectId>
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    }
}