using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ActivityPlanner.Models;

namespace ActivityPlanner.Controllers
{
    public class HomeController : Controller
    {

///////////////////////// CONTEXT /////////////////////////

        private ActivityContext _context;

        public HomeController (ActivityContext context)
        {
            _context = context;
        }

///////////////////////// INDEX /////////////////////////

        public IActionResult Index()
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO INDEX");
            System.Console.WriteLine("****************************");
            return View();
        }

///////////////////////// REGISTRATION /////////////////////////

        [HttpPost]
        [Route("ProcessReg")]
        public IActionResult ProcessReg(User CurrentUser, string ConfirmPassword)
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO PROCESSREG");
            System.Console.WriteLine("****************************");

            // if(ModelState.IsValid)
            // {
            //     PasswordHasher<User> Hasher = new Password
            // }

            _context.Add(CurrentUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("user_id", CurrentUser.UserId);
            HttpContext.Session.SetString("user_email", CurrentUser.Email);
            return RedirectToAction("Home");
        }

///////////////////////// LOGIN /////////////////////////

        [HttpPost]
        [Route("ProcessLog")]
        public IActionResult ProcessLog(string email, string password)
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO PROCESSLog");
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("email" + email);
            System.Console.WriteLine("password" + password);

            User CurrentUser = _context.users.SingleOrDefault(u => u.Email == email);
            HttpContext.Session.SetInt32("user_id", CurrentUser.UserId);
            HttpContext.Session.SetString("user_email", CurrentUser.Email);

            return RedirectToAction("Home");
        }

        [Route("Home")]
        public IActionResult Home()
        {
            ViewBag.CurrentUser = _context.users.SingleOrDefault(u => u.Email == HttpContext.Session.GetString("user_email"));
            ViewBag.AllActivities = _context.activities.Include(u => u.User).ToList();
            
            return View();
        }

        [Route("New")]
        public IActionResult NewActivity()
        {
            return View("NewActivity");
        }

        [Route("CreateActivity")]
        public IActionResult CreateActivity(ActivityPlanned NewActivity)
        {

            NewActivity.UserId = (int)HttpContext.Session.GetInt32("user_id");
            _context.Add(NewActivity);
            _context.SaveChanges();
            return RedirectToAction("ActivityDetails");
        }

        [Route("activity")]
        public IActionResult ActivityDetails()
        {
            return View();
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO LOGOUT");
            System.Console.WriteLine("****************************");

            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
