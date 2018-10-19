using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class UsersController : Controller
    {
        // home/index/form page
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("user/create")]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Result");
            }
            else
            {
                return View("Index");
            }
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
