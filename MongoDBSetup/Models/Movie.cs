using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBSetup.Models
{
    [BsonIgnoreExtraElements]
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string MovieId { get; set; } = String.Empty;

        [BsonElement("Name")]
        public string MovieName { get; set; } = String.Empty;

        [BsonElement("Director")]
        public string MovieDirector { get; set; } = String.Empty;

        [BsonElement("Distributor")]
        public string Distributor { get; set; }


    }
}
