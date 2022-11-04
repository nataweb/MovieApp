namespace MovieApp.API.Models.Domain
{
    public class Collection
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? PosterPath { get; set; }

        public string? BackdropPath { get; set; }

        public string? Overview { get; set; }
    }
}
