namespace MovieApp.API.Models.Domain
{
    public class Genre
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? MovieId { get; set; }
        public Movies Movie { get; set; }


    }
}
