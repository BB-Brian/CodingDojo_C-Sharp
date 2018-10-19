using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;
using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
 
        public HomeController(Context context)
        {
            _context = context;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("submit")]
        public IActionResult Process(Rest myReview)
        {
            _context.reviews.Add(myReview);
            // OR _context.Users.Add(NewPerson);
            _context.SaveChanges();
            return RedirectToAction("Reviews");
        }

        [Route("reviews")]
        public IActionResult Reviews()
        {
            List<Rest> AllReviews = _context.reviews.ToList();
            
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
