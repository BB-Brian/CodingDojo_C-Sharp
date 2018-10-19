using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProfessionalNetwork.Models;


namespace ProfessionalNetwork.Controllers
{
    public class HomeController : Controller
    {
///////////////////////// CONTEXT /////////////////////////

        private NetworkContext _context;
        public HomeController(NetworkContext context){
            _context = context;
        }
        
///////////////////////// INDEX | LOGIN | REG /////////////////////////

//////////////// INDEX ////////////////

        public IActionResult Index()
        {
            return View("Index");
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
                    ViewBag.CurrentUser = user;
                    HttpContext.Session.SetInt32("UserId",(int)UserId);
                    HttpContext.Session.SetString("UserEmail",(string)user.Email);
                    HttpContext.Session.SetString("UserName",(string)user.Name);
                    return RedirectToAction("Profile");
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
                User CurrentUser = _context.users.SingleOrDefault(u => u. Email ==  Email);
                if(CurrentUser != null)
                {
                    var Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(CurrentUser, CurrentUser.Password, Password))
                    { 
                        HttpContext.Session.SetInt32("UserId",CurrentUser.UserId); 
                        HttpContext.Session.SetString(" Email",(string)CurrentUser. Email);
                        HttpContext.Session.SetString("UserFirstName",(string)CurrentUser.Name);
                        ViewBag.CurrentUser = CurrentUser;

                        return RedirectToAction("Profile");
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

///////////////////////// DASHBOARD PAGE /////////////////////////

        [Route("Profile")]
        public IActionResult Profile()
        {
            if(HttpContext.Session.GetInt32("UserId") == null) 
            {
                return RedirectToAction("Index");
            }
            else
            {
                int? UserId = HttpContext.Session.GetInt32("UserId");
                ViewBag.CurrentUser = _context.users.SingleOrDefault(u => u.UserId == (int)UserId);
                // ViewBag.AllAuctions = _context.auctions.Include(u => u.User).Include(b => b.bids).OrderBy(t => t.EndDate).ToList();
                return View();
            }
        }

///////////////////////// AllUsers /////////////////////////

        [Route("users")]
        public IActionResult Users()
        {
            ViewBag.AllUsers = _context.users.ToList();
            return View();
        }


///////////////////////// FUNCTIONALITY /////////////////////////





//////////////// LOGOUT ////////////////

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

//////////////// BUILT-IN ////////////////

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}

