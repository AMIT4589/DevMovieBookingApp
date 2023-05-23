using MongoDB.Driver;
using MongoDBSetup.Models;

namespace MongoDBSetup.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMongoCollection<Movie> _Movies;

        public MovieService(IMongoDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _Movies = database.GetCollection<Movie>(settings.CollectionName[0]);
        }
        public Movie Create(Movie movie)
        {
            _Movies.InsertOne(movie);
            return movie;
        }

        public List<Movie> Get()
        {
            return _Movies.Find(student => true).ToList();
        }

        public Movie Get(string id)
        {
            return _Movies.Find(student => student.MovieId == id).FirstOrDefault();
        }

        public void Update(string id, Movie movie)
        {
            _Movies.ReplaceOne(s => s.MovieId == id, movie);
        }

        public void Delete(string id)
        {
            _Movies.DeleteOne(student => student.MovieId == id);
        }
    }
}
