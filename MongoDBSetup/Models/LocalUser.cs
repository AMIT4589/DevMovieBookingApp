using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBSetup.Models
{
    [BsonIgnoreExtraElements]
    public class LocalUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("user")]
        public string UserName { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;
        [BsonElement("role")]

        public string Role { get; set; } = string.Empty;

    }
}
