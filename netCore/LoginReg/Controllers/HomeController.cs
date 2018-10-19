using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;

namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;
    
        public HomeController(UserContext context)
        {
            _context = context;
        }
 
        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser(User MyUser, string ConfirmPassword)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("LoginUser")]
        public IActionResult LoginUser(User MyUser, string ConfirmPassword)
        {

            return RedirectToAction("Index");
        }


        // public IActionResult Index()
        // {
        //     List<User> AllUsers = _context.Users.ToList();
        //     // Other code
        // }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
