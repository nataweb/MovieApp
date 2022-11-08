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
      
        public DbSet<Movies> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movies> CollectionInfo { get; set; }
        public DbSet<ProductionCompanies> ProductionCompanies { get; set; }
        public DbSet<ProductionCountries> ProductionCountries { get; set; }
        public DbSet<SpokenLanguages> SpokenLanguages { get; set; }
    }
}
