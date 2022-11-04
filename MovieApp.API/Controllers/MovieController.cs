using Microsoft.AspNetCore.Mvc;

namespace MovieApp.API.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
