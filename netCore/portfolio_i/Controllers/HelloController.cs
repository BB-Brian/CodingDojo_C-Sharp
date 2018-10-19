using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace portfolio_i.Controllers     //be sure to use your own project's namespace!
{
    public class HelloController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public IActionResult Index()
        {
            // Here we assign the value "Using ViewBag!" to the property .Example
            // Property names are arbitrary and can be whatever you like
            // When the resulting view is rendered, it will have access to the ViewBag property that we set.
            ViewBag.Example = "Using ViewBag in Controller -> 'ViewBag.Example'!";
            
            // to render a cshtml page
            return View();
            //OR
            // return View("Index");
        }

        [HttpGet]
        [Route("projects")]
        public string Projects()
        {
            return "These are my projects";
        }

        [HttpGet]
        [Route("contact")]
        public string Contact()
        {
            return "This is my Contact!";
        }


        // [HttpGet]
        // [Route("template/{name}")]
        // public JsonResult Method(string name)
        // {
        //     return ;
        // }

        // [HttpGet]
        // [Route("template/{id}/{action}")]
        // public JsonResult Method(int id, string action)
        // {
        //     return ;
        // }
    }
}