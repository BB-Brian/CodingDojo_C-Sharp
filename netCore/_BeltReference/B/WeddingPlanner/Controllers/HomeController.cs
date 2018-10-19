using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {

///////////////////////// CONTEXT /////////////////////////

        private WeddingContext _context;

        public HomeController (WeddingContext context)
        {
            _context = context;
        }

///////////////////////// ROUTING & PROCESSES /////////////////////////

        public IActionResult Index()
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO INDEX");
            System.Console.WriteLine("****************************");
            return View();
        }

//////////////// REG ////////////////

       [HttpPost("Register")]
        public IActionResult Register(User user, string PasswordConfirm)
        {
            if(user.Password != PasswordConfirm)
            {
                ViewBag.PasswordError = "Passwords don't match";
                return View("Index");
            }
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                User ExistingEmail = _context.users.SingleOrDefault(u => u.Email == user.Email);
            
                if(ExistingEmail != null)
                {
                    ViewBag.RegError = "Email already registered";
                    return View("Index");
                }
                else
                {
                    _context.Add(user);
                    _context.SaveChanges();

                    int? UserId = user.UserId;
                    HttpContext.Session.SetInt32("UserId",(int)UserId);
                    return RedirectToAction("Dashboard");
                }
            }
            else
            {
                return View("Index");
            }
        }

//////////////// LOGIN ////////////////

        [HttpPost("Login")]
        public IActionResult Login(string Email, string Password)
        {
            if(Email==null || Password==null)
            {
                ViewBag.LogError = "Cannot leave field(s) blank.";
                return View("Index");
            }
            else
            {
                User CurrentUser = _context.users.SingleOrDefault(u => u.Email == Email);
                if(CurrentUser != null)
                {
                    var Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(CurrentUser, CurrentUser.Password, Password))
                    { 
                        HttpContext.Session.SetInt32("UserId",CurrentUser.UserId); 
                        HttpContext.Session.SetString("First Name",(string)CurrentUser.FirstName);
                        return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        ViewBag.LogError = "Invalid login";
                        return View("Index");
                    }
                }
                else
                {
                    ViewBag.LogError = "Invalid login"; 
                    return View("Index");
                }
            }
        }
///////////////////////// DASHBOARD /////////////////////////


        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO DASHBOARD");
            System.Console.WriteLine("****************************");

            if(HttpContext.Session.GetInt32("UserId") == null) 
            {
                return RedirectToAction("Index");
            }
            else
            {
                int? UserId = HttpContext.Session.GetInt32("UserId");
                
                ViewBag.CurrentUser = _context.users.SingleOrDefault(u => u.UserId == (int)UserId);
                ViewBag.AllWeddings = _context.weddings.Include(p => p.User).Include(l => l.Guests).ThenInclude(u => u.User).ToList();
                
            return View();
            }

        }

///////////////////////// ROUTE TO CREATE WEDDING  /////////////////////////

        [Route("NewWedding")]
        public IActionResult NewWedding()
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO NEWWEDDINGBUTTON");
            System.Console.WriteLine("****************************");

            return RedirectToAction("CreateWedding");
        }

 ///////////////////////// RENDER CREATE WEDDING PAGE /////////////////////////

        public IActionResult CreateWedding()        
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO CREATEWEDDING");
            System.Console.WriteLine("****************************");

            ViewBag.DateError = TempData["DateError"];

            return View();
        }

///////////////////////// PROCESS CREATE WEDDING /////////////////////////

        [HttpPost]
        [Route("ProcessCreateWedding")]
        public IActionResult ProcessCreateWedding(Wedding NewWedding)
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO PROCESSCREATEWEDDING");
            System.Console.WriteLine("****************************");

            int CurrentUserId = (int)HttpContext.Session.GetInt32("UserId");
            
            if(NewWedding.Date < DateTime.Now)
            {
                TempData["DateError"] = "Wedding date cannot be in the past";
                return RedirectToAction("CreateWedding");
            }
            else
            {
            NewWedding.UserId = CurrentUserId;
            _context.Add(NewWedding);
            _context.SaveChanges();

            return RedirectToAction("WeddingDetails", new { WeddingId = NewWedding.WeddingId });
            }
        }

///////////////////////// RENDER WEDDING DETAILS /////////////////////////

        [HttpGet]
        [Route("WeddingDetails/{WeddingId}")]
        public IActionResult WeddingDetails(int WeddingId)
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO WEDDINGDETAILS");
            System.Console.WriteLine("****************************");
           
            Wedding CurrentWedding = _context.weddings.Include(u => u.Guests).ThenInclude(u => u.User).SingleOrDefault(w => w.WeddingId == WeddingId);
            ViewBag.Wedding = CurrentWedding;
        
            return View();
        }

///////////////////////// ADDITIONAL FUNCTIONALITY /////////////////////////

        [Route("Logout")]
        public IActionResult Logout()
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO LOGOUT");
            System.Console.WriteLine("****************************");

            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }

///////////////////////// RSVP / unRSVP /////////////////////////

        [Route("RSVP/{WeddingId}/")]
        public IActionResult RSVP(int WeddingId)
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO RSVP");
            System.Console.WriteLine("****************************");

            int? Userid = HttpContext.Session.GetInt32("UserId");
            Guest NewRSVP = new Guest
            {
                UserId = (int)Userid,
                WeddingId = WeddingId
            };
            _context.guests.Add(NewRSVP);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [Route("unRSVP/{WeddingId}")]
        public IActionResult unRSVP(int WeddingId)
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO unRSVP");
            System.Console.WriteLine("****************************");

            int? UserId = HttpContext.Session.GetInt32("UserId");
            Guest unRSVP = _context.guests.SingleOrDefault(g => g.UserId == (int)UserId && g.WeddingId == WeddingId);
            _context.guests.Remove(unRSVP);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

///////////////////////// DELETE /////////////////////////

        [Route("Delete/{WeddingId}")]
        public IActionResult Delete(int WeddingId)
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO DELETE");
            System.Console.WriteLine("****************************");

            Wedding WeddingToDelete = _context.weddings.SingleOrDefault(w => w.WeddingId == WeddingId);
            _context.weddings.Remove(WeddingToDelete);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
