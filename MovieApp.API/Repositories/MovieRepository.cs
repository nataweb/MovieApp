using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Movies> AddAsync(Movies movie)
        {
            movie.Id = new int();
            
            await movieDbContext.AddAsync(movie); 
            await movieDbContext.SaveChangesAsync(); 
            return movie;   
        }

        public async Task<Movies> DeleteAsync(int Id)
        {
            var movie = await movieDbContext.Movies.FirstOrDefaultAsync(x => x.Id == Id);

            if (movie == null) 
            {
                return null;
            }
            //Delete the movie
            movieDbContext.Movies.Remove(movie);
            movieDbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<IEnumerable<Movies>> GetAllAsync()
        {
            return await movieDbContext.Movies.ToListAsync();
        }

        public async Task<Movies> GetAsync(int Id)
        {
          return await movieDbContext.Movies.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Movies> UpdateAsync(int Id, Movies movie)
        {
            var existingMovie = await movieDbContext.Movies.FirstOrDefaultAsync(x => x.Id == Id);

            if (existingMovie == null)
            {
                return null;
            }

            existingMovie.Title = existingMovie.Title;
            existingMovie.BackdropPath= existingMovie.BackdropPath;
            existingMovie.Budget= existingMovie.Budget;
            existingMovie.Homepage= existingMovie.Homepage;
            existingMovie.ImdbId = existingMovie.ImdbId;
            existingMovie.OriginalLanguage = existingMovie.OriginalLanguage;
            existingMovie.OriginalTitle = existingMovie.OriginalTitle;
            existingMovie.Overview= existingMovie.Overview;
            existingMovie.Popularity = existingMovie.Popularity;
            existingMovie.PosterPath= existingMovie.PosterPath;
            existingMovie.ReleaseDate= existingMovie.ReleaseDate;
            existingMovie.Revenue = existingMovie.Revenue;
            existingMovie.Runtime= existingMovie.Runtime;
            existingMovie.Status= existingMovie.Status;
            existingMovie.Tagline = existingMovie.Tagline;

            await movieDbContext.SaveChangesAsync();
            
            return existingMovie;   




        }
    }
}
