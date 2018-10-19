using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoginRegDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
namespace LoginRegDemo.Controllers {
    public class HomeController : Controller {
        private UserContext _context;
        private object userFactory;
        public HomeController (UserContext context) {
            _context = context;
        }
        public IActionResult Index () {
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
                User ExistingUser = _context.users.SingleOrDefault (u => u.Email == MyUser.Email);
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
                    // grabs all reviews from database
                    return RedirectToAction ("Success");
                }
            } else {
                System.Console.WriteLine ("There were errors adding user returned to index********************");
                return View ("Index");
            }
        }
        public IActionResult Success () {
            List<User> AllUsers = _context.users.ToList ();
            List<Account> AllAccounts = _context.accounts.ToList ();
            ViewBag.AllUsers = AllUsers;
            ViewBag.AllAccounts = AllAccounts;
            string UserSessionFirstName = HttpContext.Session.GetString("UserSessionFirstName");
            ViewBag.SessionN = UserSessionFirstName;
            return View ();
        }
        // [HttpPost]
        // [Route ("LoginUser")]
        // public IActionResult LoginUser (string Email, string Password) {
        //     //is user in database???? Use where or Singleordefault or firstordefault
        //     //check queried user's password against our passed in password
        //     //go to success(maybe add stuff to session first?)
        //     //otherwise, get some error messages to our user
        //     return RedirectToAction ("Index");
        // }
        [HttpPost]
        [Route("LoginUser")]
        public IActionResult LoginUser(string email, string Password){
            
            var user = _context.users.SingleOrDefault(u => u.Email == email);
            if(user != null && Password != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(user, user.Password, Password)){
                    HttpContext.Session.SetString("UserSessionFirstName", user.FirstName);
                    
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

        // [HttpPost]
        // [Route("AddTransaction")]
        // public IActionResult AddTransaction(Transaction transaction) {
        // }
        // public IActionResult About()
        // {
        //     ViewData["Message"] = "Your application description page.";
        //     return View();
        // }
        // public IActionResult Contact()
        // {
        //     ViewData["Message"] = "Your contact page.";
        //     return View();
        // }
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}