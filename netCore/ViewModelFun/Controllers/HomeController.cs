using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            string msg = "Code Code Code yo Code. I like to code and eat and drink coffee.";
            return View("Index", msg);
        }
         
        [Route("numbers")]
        public IActionResult Numbers()
        {
            int[] numbers = {1,2,3,4,5};
            return View("Numbers", numbers);
        }

        [Route("user")]
        public IActionResult UserPage()
        {
            User RobotUser = new User("Robot", "Unicorn");
            return View("UserPage", RobotUser);
        }

        [Route("users")]
        public IActionResult Users()
        {
            List<User> AllUsers = new List<User>();
            User KnivesChao = new User("Knives", "Chao");
            User ScottPilgrim = new User("Scott", "Pilgrim");
            User Envy = new User("Envy", " ");
            AllUsers.Add(KnivesChao);
            AllUsers.Add(ScottPilgrim);
            AllUsers.Add(Envy);
            return View("Users", AllUsers);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
