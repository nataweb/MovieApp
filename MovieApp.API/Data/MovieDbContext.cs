using Microsoft.EntityFrameworkCore;
using MovieApp.API.Models.Domain;
using MovieApp.API.Models.DTO;

namespace MovieApp.API.Data
{
    public class MovieDbContext:DbContext
    {
        internal object Movie;

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
                
        }
      
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<CollectionInfo> CollectionInfo { get; set; }
        public DbSet<ProductionCompanies> ProductionCompany { get; set; }
        public DbSet<ProductionCountries> ProductionCountry { get; set; }
        public DbSet<SpokenLanguages> SpokenLanguage { get; set; }

       
    }
}
