using MongoDBSetup.Models;

namespace MongoDBSetup.Services
{
    public interface IMovieService
    {
        List<Movie> Get();
        Movie Get(string id);
        Movie Create(Movie student);
        void Update(string id, Movie student);
        void Delete(string id);
    }
}
