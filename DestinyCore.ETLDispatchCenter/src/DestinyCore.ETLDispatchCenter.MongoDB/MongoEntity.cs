using MongoDB.Bson;
using DestinyCore.ETLDispatchCenter.Shared.Entity;

namespace DestinyCore.ETLDispatchCenter.MongoDB
{
    public abstract class MongoEntity : IEntity<ObjectId>
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    }
}