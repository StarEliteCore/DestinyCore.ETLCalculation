using MongoDB.Bson;
using Destiny.Core.TaskScheduler.Shared.Entity;

namespace Destiny.Core.TaskScheduler.MongoDB
{
    public abstract class MongoEntity : IEntity<ObjectId>
    {
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    }
}