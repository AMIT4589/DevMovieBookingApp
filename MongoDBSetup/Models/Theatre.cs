using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBSetup.Models
{
    [BsonIgnoreExtraElements]
    public class Theatre
    {


        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string TheatreId { get; set; } = String.Empty;

        [BsonElement("city")]
        public string City { get; set; } = String.Empty;

        [BsonElement("state")]
        public string State { get; set; } = String.Empty;




    }
}

