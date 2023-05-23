using MongoDBSetup.Models;

namespace MongoDBSetup.Services
{
    public interface ITheatreService
    {
        List<Theatre> Get();
        Theatre Get(string id);
        Theatre Create(Theatre theatre);
        void Update(string id, Theatre theatre);
        void Delete(string id);
    }
}
