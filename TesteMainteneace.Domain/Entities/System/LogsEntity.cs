using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TesteMainteneace.Domain.Entities.System
{
    public sealed class LogsEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; }
        public string Id { get; set; }
        public string ClassError { get; set; }
        public string LineError { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string LogRef { get; set; }
        public List<string> Erros { get; set; }

    }
}
