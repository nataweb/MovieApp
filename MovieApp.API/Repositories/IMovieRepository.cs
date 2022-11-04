using MovieApp.API.Models.Domain;

namespace MovieApp.API.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
    }
}
