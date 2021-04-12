using MongoDB.Bson;
using DestinyCore.WorkNode.Shared.Entity;

namespace DestinyCore.WorkNode.MongoDB
{
    public abstract class MongoEntity : IEntity<ObjectId>
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    }
}