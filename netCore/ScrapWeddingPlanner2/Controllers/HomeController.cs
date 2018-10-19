using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext _context;

        public HomeController (WeddingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO INDEX");
            System.Console.WriteLine("****************************");
            return View();
        }

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
            return RedirectToAction("Dashboard");
        }

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

            return RedirectToAction("Dashboard");
        }

        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO DASHBOARD");
            System.Console.WriteLine("****************************");

            ViewBag.CurrentUser = _context.users.SingleOrDefault(u => u.Email == HttpContext.Session.GetString("user_email"));;

            List<Wedding> AllWeddings = _context.weddings.Include(g => g.Guests).ThenInclude(u => u.User).ToList(); 
            
            HttpContext.Session.GetInt32("wedding_id");

            return View(AllWeddings);
        }

        [Route("NewWedding")]
        public IActionResult NewWedding()
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO CREATEWEDDING");
            System.Console.WriteLine("****************************");

            return RedirectToAction("CreateWedding");
        }

        public IActionResult CreateWedding()
        {
            return View();
        }

        [Route("ProcessCreateWedding")]
        public IActionResult ProcessCreateWedding(Wedding NewWedding)
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO PROCESSCREATEWEDDING");
            System.Console.WriteLine("****************************");
            
            User CurrentUser = _context.users.SingleOrDefault(u => u.UserId == HttpContext.Session.GetInt32("user_id"));

            NewWedding.UserId = CurrentUser.UserId;
            _context.Add(NewWedding);
            _context.SaveChanges();


            // Wedding CreatedWedding = _context.weddings.SingleOrDefault(w => w.WeddingId == NewWedding.WeddingId);
            // , new { WeddingId = NewWedding.WeddingId}
            return RedirectToAction("Wedding");
        }
        
        
        public IActionResult Wedding()
        {
            // int WeddingId

            // Wedding CurrentWedding = _context.weddings.SingleOrDefault(w => w.WeddingId == WeddingId);
            return View();
        }

        // [Route("Wedding/{WeddingId}")]
        // public IActionResult Wedding(int WeddingId)
        // {
        //     System.Console.WriteLine("****************************");
        //     System.Console.WriteLine("MADE IT TO WEDDING");
        //     System.Console.WriteLine("****************************");
        //     System.Console.WriteLine(WeddingId);

        //     Wedding CurrentWedding = _context.weddings.SingleOrDefault(w => w.WeddingId == WeddingId);

        //     return View("Wedding");
        // }

        [Route("ReturnToDashboard")]
        public IActionResult ReturnToDashboard()
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO RETURNTODASHBOARD");
            System.Console.WriteLine("****************************");

            return RedirectToAction("Dashboard");
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
