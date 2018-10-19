using Microsoft.AspNetCore.Mvc;

namespace razorFun.Controllers
{
    public class RazorFunController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Home()
        {
            return View("RazorFun");
        }
    }
}