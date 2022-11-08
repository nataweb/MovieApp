namespace MovieApp.API.Models.Domain
{
    public class ProductionCountries
    {
        public int Id { get; set; }

        public string Iso_3166_1 { get; set; }

        public string Name { get; set; }

        public int MoviesId { get; set; }
    }
}
