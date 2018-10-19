using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            // DateTime CurrentTime
            return View("index");
        }
    }
}