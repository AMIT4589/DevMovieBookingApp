using MongoDB.Driver;
using MongoDBSetup.Models;

namespace MongoDBSetup.Services
{
    public class TheatreService : ITheatreService

    {
        private readonly IMongoCollection<Theatre> _Theatres;

        public TheatreService(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _Theatres = database.GetCollection<Theatre>(settings.CollectionName[1]);
        }
        public Theatre Create(Theatre theatre)
        {
            _Theatres.InsertOne(theatre);
            return theatre;
        }

        public List<Theatre> Get()
        {
            return _Theatres.Find(theatre => true).ToList();
        }

        public Theatre Get(string id)
        {
            return _Theatres.Find(theatre => theatre.TheatreId == id).FirstOrDefault();
        }

        public void Update(string id, Theatre theatre)
        {
            _Theatres.ReplaceOne(s => s.TheatreId == id, theatre);
        }

        public void Delete(string id)
        {
            _Theatres.DeleteOne(theatre => theatre.TheatreId == id);
        }
    }
}
