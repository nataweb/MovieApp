using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Repositories;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MoviesController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
       [HttpGet]
       public IActionResult GetAllMovies() 
       {
          var movies = movieRepository.GetAll();

            return Ok(movies);
       }
    }
}
