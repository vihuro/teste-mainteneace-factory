using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TesteMainteneace.Domain.Entities
{
    public sealed class LogsEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; }
        public string Id { get; set; }
        public string LogRef { get; set; }
        public List<string> Message { get; set; }
    }
}
