using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiCommon.MongoDatabase.Abstractions
{
    public abstract class BaseDbModelStringId : IId
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
