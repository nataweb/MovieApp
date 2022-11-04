using Microsoft.EntityFrameworkCore;
using MovieApp.API.Models.Domain;

namespace MovieApp.API.Data
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base(options)
        {
                
        }
      
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> CollectionInfo { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<ProductionCountry> ProductionCountries { get; set; }
        public DbSet<SpokenLanguage> SpokenLanguages { get; set; }
    }
}
