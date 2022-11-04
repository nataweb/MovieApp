using MovieApp.API.Data;
using MovieApp.API.Models.Domain;

namespace MovieApp.API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext movieDbContext;

        public MovieRepository(MovieDbContext movieDbContext)
        {
            this.movieDbContext = movieDbContext;
        }
        public IEnumerable<Movie> GetAll()
        {
           return movieDbContext.Movies.ToList();
        }
    }
}
