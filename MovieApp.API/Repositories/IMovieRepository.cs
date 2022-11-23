using MovieApp.API.Models.Domain;

namespace MovieApp.API.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movies>> GetAllAsync();

        Task<Movies> GetAsync(int Id);

        Task<Movies> AddAsync(Movies movie);

        Task<Movies> DeleteAsync(int Id);

        Task<Movies> UpdateAsync(int Id,Movies movie);
    }
}
