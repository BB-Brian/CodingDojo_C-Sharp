using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoginRegDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LoginRegDemo.Controllers {
    public class HomeController : Controller {

        private UserContext _context;

        public HomeController (UserContext context) {
            _context = context;
        }

        public IActionResult Index () {
            HttpContext.Session.SetString("user", "");
            return View ();
        }

        [HttpPost]
        [Route ("RegisterUser")]
        public IActionResult RegisterUser (User MyUser, string ConfirmPassword) {
            
            System.Console.WriteLine ("WE HIT REGISTERED USER FUNCTION IN CONTROLLER");
            if(MyUser.Password != ConfirmPassword) {
                System.Console.WriteLine("DAMN HOMIE your passwords dont match **************************");
                ViewBag.PasswordError = $"{MyUser.FirstName} I'm so terribly sorry but I'm a robot and I don't understand why you would type passwords that don't match. THANKS FOR PLAYING. TRY AGAIN!";
                return View ("Index");
            }

            if (ModelState.IsValid) {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                MyUser.Password = Hasher.HashPassword(MyUser, MyUser.Password);
                User ExistingUser = _context.User.SingleOrDefault (u => u.Email == MyUser.Email);
                if (ExistingUser != null) {
                    System.Console.WriteLine (" *************EMAIL ALREADY IN USE**********************");
                    ViewBag.AlreadyInUseEmail = true;
                    // ViewBag.AlreadyInUseEmail = $"{MyUser.Email} is already in the Data base, YOU FUCK!";
                    return View ("Index");
                    // Yo dude Have you ever watched Mike Tyson Mysteries? Its really good show.
                }
                else{
                    _context.Add (MyUser);
                    _context.SaveChanges ();
                    HttpContext.Session.SetString("user", MyUser.Email);
                    // grabs all reviews from database
                    return RedirectToAction ("Success");
                }
            } else {
                System.Console.WriteLine ("There were errors adding user returned to index********************");
                return View ("Index");
            }

        }

        
        public IActionResult Success () {
            // List<User> Alluser = _context.user.ToList ();
            User users = _context.User.SingleOrDefault(us => us.Email == HttpContext.Session.GetString("user"));
            ViewBag.User = users;
            // List<Wedding> Weddings = _context.weddings.ToList();
            List<Wedding> Weddings = _context.weddings.Include(ig => ig.Guests).ToList();
            ViewBag.Weddings = Weddings;
            return View();
        }

        
        [HttpPost]
        [Route("LoginUser")]
        public IActionResult Login(string email, string Password){
            
            var users = _context.User.SingleOrDefault(u => u.Email == email);
            if(users != null && Password != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(users, users.Password, Password)){
                    HttpContext.Session.SetString("user", email);
                    return RedirectToAction("Success");
                }
                else{
                    System.Console.WriteLine("*************************$$$$$$$$$$$#################################$$$$$$$$$$$$$$************");
                    System.Console.WriteLine("Else for login if password doesnt match");
                    System.Console.WriteLine("*************************$$$$$$$$$$$#################################$$$$$$$$$$$$$$************");

                    ViewBag.loginError = "Wrong password!";
                    return View("Index");
                }
            }
            else{
                System.Console.WriteLine("*************************$$$$$$$$$$$#################################$$$$$$$$$$$$$$************");
                System.Console.WriteLine("Else for login email doesnt exist");
                System.Console.WriteLine("*************************$$$$$$$$$$$#################################$$$$$$$$$$$$$$************");

                ViewBag.loginError = "Email not registered";
                return View("Index");
            }
            
        }
        

        public IActionResult NewWedding()
        {

            return View();
        }
        
        [Route("Home/Delete/{id}")]
        public IActionResult Delete(int id) 
        {
           Wedding RemoveWedding = _context.weddings.SingleOrDefault(u => u.WeddingId == id);
            _context.weddings.Remove(RemoveWedding);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }

        public IActionResult Process(Wedding NewWedding){
            if (ModelState.IsValid){
                User users = _context.User.SingleOrDefault(us => us.Email == HttpContext.Session.GetString("user"));
                NewWedding.UserId = users.UserId;
                _context.Add(NewWedding);
                _context.SaveChanges();                       
                return RedirectToAction("Success");
            }
            else{
                System.Console.WriteLine("Errors validating wedding***********");
                return View("NewWedding");
            }
        }

        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}