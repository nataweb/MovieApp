namespace MovieApp.API.Models.Domain
{
    public class SpokenLanguages
    {
        public int Id { get; set; }

        public string? EnglishName { get; set; }

        public string? Iso_639_1 { get; set; }

        public string? Name { get; set; }

        public int? MoviesId { get; set; }
    }
}
