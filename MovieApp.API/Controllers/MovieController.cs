using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Models.Domain;
using MovieApp.API.Models.DTO;
using MovieApp.API.Repositories;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MoviesController : Controller
    {
        private readonly IMovieRepository movieRepository;
        private readonly IMapper mapper;

        public MoviesController(IMovieRepository movieRepository,
            IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllMoviesAsync() 
       {
          var movies = await movieRepository.GetAllAsync();

            //return DTO movies
            //var moviesDTO = new List<Models.DTO.Movie>();

            //movies.ToList().ForEach(movie =>
            //    {
            //        var movieDTO = new Models.DTO.Movie()
            //        {
            //            Id = movie.Id,
            //            Title = movie.Title,
            //            BackdropPath = movie.BackdropPath,
            //            Budget = movie.Budget,
            //            Homepage = movie.Homepage,
            //            ImdbId = movie.ImdbId,
            //            OriginalLanguage = movie.OriginalLanguage,
            //            OriginalTitle = movie.OriginalTitle,
            //            Overview = movie.Overview,
            //            Popularity = movie.Popularity,
            //            PosterPath = movie.PosterPath,
            //            ReleaseDate = movie.ReleaseDate,
            //            Revenue = movie.Revenue,
            //            Runtime = movie.Runtime,
            //            Status = movie.Status,
            //            Tagline = movie.Tagline
            //        };
            //  moviesDTO.Add(movieDTO);
            //});


          var moviesDTO = mapper.Map<List<Models.DTO.Movie>>(movies);
          return Ok(moviesDTO);
       }

        [HttpGet]
        [Route("{Id}")]
        [ActionName("GetMovieAsync")]
        public async Task<IActionResult> GetMovieAsync(int Id)
        {
           var movie = await movieRepository.GetAsync(Id);

           if (movie == null) 
           {
                return NotFound();
           } 

           var movieDTO = mapper.Map<Models.DTO.Movie>(movie);

           return Ok(movieDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieAsync(Models.DTO.AddMovieRequest addMovieRequest)
        {
            // Request to Domain Model
            var movie = new Models.Domain.Movies()
            {
                Title = addMovieRequest.Title,

                BackdropPath = addMovieRequest.BackdropPath,

                Budget = addMovieRequest.Budget,

                Homepage = addMovieRequest.Homepage,

                ImdbId = addMovieRequest.ImdbId,

                OriginalLanguage = addMovieRequest.OriginalLanguage,

                OriginalTitle = addMovieRequest.OriginalTitle,

                Overview = addMovieRequest.Overview,

                Popularity = addMovieRequest.Popularity,

                PosterPath = addMovieRequest.PosterPath,

                ReleaseDate = addMovieRequest.ReleaseDate,

                Revenue = addMovieRequest.Revenue,

                Runtime = addMovieRequest.Runtime,

                Status = addMovieRequest.Status,

                Tagline = addMovieRequest.Tagline

            };
            //Pass details to Repository
            movie = await movieRepository.AddAsync(movie);

            //Convert to DTO
            var movieDTO = new Models.DTO.Movie
            {
                Id = movie.Id,

                Title = movie.Title,

                BackdropPath = movie.BackdropPath,

                Budget = movie.Budget,

                Homepage = movie.Homepage,

                ImdbId = movie.ImdbId,

                OriginalLanguage = movie.OriginalLanguage,

                OriginalTitle = movie.OriginalTitle,

                Overview = movie.Overview,

                Popularity = movie.Popularity,

                PosterPath = movie.PosterPath,

                ReleaseDate = movie.ReleaseDate,

                Revenue = movie.Revenue,

                Runtime = movie.Runtime,

                Status = movie.Status,

                Tagline = movie.Tagline

            };
            return CreatedAtAction(nameof(GetMovieAsync),new {Id = movieDTO.Id },movieDTO);

          
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteMovieAsync(int Id) 
        {
            //get movie from database
           var movie = await movieRepository.DeleteAsync(Id);
            //If null found NotFound
            if (movie == null) 
            {
                return NotFound();
            }
            //Convert response to DTO
            var movieDTO = new Models.DTO.Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                BackdropPath = movie.BackdropPath,
                Budget = movie.Budget,
                Homepage = movie.Homepage,
                ImdbId = movie.ImdbId,
                OriginalLanguage = movie.OriginalLanguage,
                OriginalTitle = movie.OriginalTitle,
                Overview = movie.Overview,
                Popularity = movie.Popularity,
                PosterPath = movie.PosterPath,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                Runtime = movie.Runtime,
                Status = movie.Status,
                Tagline = movie.Tagline


            };

            return Ok(movieDTO);
        }

        [HttpPut]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateMovieAsync(int Id,Models.DTO.UpdateMovieRequest updateMovieRequest)
        {
            //Convert DTO to Domain Model
            var movie = new Models.Domain.Movies
            {
                Title = updateMovieRequest.Title,

                BackdropPath = updateMovieRequest.BackdropPath,

                Budget = updateMovieRequest.Budget,

                Homepage = updateMovieRequest.Homepage,

                ImdbId = updateMovieRequest.ImdbId,

                OriginalLanguage = updateMovieRequest.OriginalLanguage,

                OriginalTitle = updateMovieRequest.OriginalTitle,

                Overview = updateMovieRequest.Overview,

                Popularity = updateMovieRequest.Popularity,

                PosterPath = updateMovieRequest.PosterPath,

                ReleaseDate = updateMovieRequest.ReleaseDate,

                Revenue = updateMovieRequest.Revenue,

                Runtime = updateMovieRequest.Runtime,

                Status = updateMovieRequest.Status,

                Tagline = updateMovieRequest.Tagline

            };
            //Update movie using repository
            movie = await movieRepository.UpdateAsync(Id, movie);
            //If Null then NotFound
            if(movie == null)
            {
                return NotFound();
            }
            //Convert Domain back to DTO
            var movieDTO = new Models.DTO.Movie
            {
                Id = movie.Id,

                Title = movie.Title,

                BackdropPath = movie.BackdropPath,

                Budget = movie.Budget,

                Homepage = movie.Homepage,

                ImdbId = movie.ImdbId,

                OriginalLanguage = movie.OriginalLanguage,

                OriginalTitle = movie.OriginalTitle,

                Overview = movie.Overview,

                Popularity = movie.Popularity,

                PosterPath = movie.PosterPath,

                ReleaseDate = movie.ReleaseDate,

                Revenue = movie.Revenue,

                Runtime = movie.Runtime,

                Status = movie.Status,

                Tagline = movie.Tagline

            };

            //Return Ok response
            return Ok(movieDTO);
        }

    }
}
