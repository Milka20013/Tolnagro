using MongoDB.Bson.Serialization.Attributes;

namespace Tolnagro_Test_Backend.Models
{
    public class RootModel
    {
        [BsonId]
        [BsonElement("_id")]
        public string? Id { get; set; }
    }
}
