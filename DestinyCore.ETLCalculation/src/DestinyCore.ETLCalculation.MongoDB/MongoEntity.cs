using MongoDB.Bson;
using DestinyCore.ETLCalculation.Shared.Entity;

namespace DestinyCore.ETLCalculation.MongoDB
{
    public abstract class MongoEntity : IEntity<ObjectId>
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    }
}