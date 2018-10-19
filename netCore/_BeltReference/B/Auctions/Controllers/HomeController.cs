using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Auctions.Models;


namespace Auctions.Controllers
{
    public class HomeController : Controller
    {
///////////////////////// CONTEXT /////////////////////////

        private AuctionsContext _context;
        public HomeController(AuctionsContext context){
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
                User ExistingUsername = _context.users.SingleOrDefault(u => u.Username == user.Username);
                if(ExistingUsername != null)
                {
                    ViewBag.RegError = "Username already registered";
                    return View("Index");
                }
                else
                {
                    _context.Add(user);
                    _context.SaveChanges();

                    int? UserId = user.UserId;
                    ViewBag.CurrentUser = user;
                    HttpContext.Session.SetInt32("UserId",(int)UserId);
                    HttpContext.Session.SetString("UserUsername",(string)user.Username);
                    HttpContext.Session.SetString("UserFirstName",(string)user.FirstName);
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
        public IActionResult Login(string Username, string Password)
        {
            if(Username==null || Password==null)
            {
                ViewBag.LogError = "Cannot leave field(s) blank.";
                return View("Index");
            }
            else
            {
                User CurrentUser = _context.users.SingleOrDefault(u => u.Username == Username);
                if(CurrentUser != null)
                {
                    var Hasher = new PasswordHasher<User>();
                    if(0 != Hasher.VerifyHashedPassword(CurrentUser, CurrentUser.Password, Password))
                    { 
                        HttpContext.Session.SetInt32("UserId",CurrentUser.UserId); 
                        HttpContext.Session.SetString("Username",(string)CurrentUser.Username);
                        HttpContext.Session.SetString("UserFirstName",(string)CurrentUser.FirstName);
                        ViewBag.CurrentUser = CurrentUser;

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

///////////////////////// DASHBOARD PAGE /////////////////////////

        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("UserId") == null) 
            {
                return RedirectToAction("Index");
            }
            else
            {
                int? UserId = HttpContext.Session.GetInt32("UserId");
                ViewBag.CurrentUser = _context.users.SingleOrDefault(u => u.UserId == (int)UserId);
                ViewBag.AllAuctions = _context.auctions.Include(u => u.User).Include(b => b.bids).OrderBy(t => t.EndDate).ToList();
                // ViewBag.HighestBid = _context.bids.Include(u => u.User).Include(a => a.Auction).OrderByDescending(b => b.BidAmount).ToList().Take(1);
                return View();
            }
        }

///////////////////////// NEW AUCTION PAGE /////////////////////////

        [Route("NewAuction")]
        public IActionResult NewAuction()
        {
            ViewBag.FormError = TempData["FormError"];
            ViewBag.DateError = TempData["DateError"];
            return View();
        }

///////////////////////// AUCTION DETAILS PAGE /////////////////////////

        [Route("AuctionDetails/{AuctionId}")]
        public IActionResult AuctionDetails(int AuctionId)
        {
            Auction CurrentAuction = _context.auctions.Include(u => u.User).Include(b => b.bids).ThenInclude(u => u.User).SingleOrDefault(a => a.AuctionId == AuctionId);
            ViewBag.CurrentAuction = CurrentAuction;

            ViewBag.HighestBid = _context.bids.Include(u => u.User).Include(a => a.Auction).OrderByDescending(b => b.BidAmount).ToList().Take(1);
            

            return View();
        }

///////////////////////// FUNCTIONALITY /////////////////////////

//////////////// CREATE AUCTION ////////////////

        [HttpPost("CreateAuction")]
        public IActionResult CreateAuction(Auction NewAuction)
        {
            if(!ModelState.IsValid)
            {
                if(NewAuction.StartingBid < 1)
                { 
                    ViewBag.BidError = "Starting bid must be greater than zero";
                    return View("NewAuction");
                }
                if(NewAuction.EndDate < DateTime.Now)
                {
                    ViewBag.DateError = "Auction end date must be in the future";
                    return View("NewAuction");
                }
                return View("NewAuction");
            }
            else
            {
                NewAuction.UserId = (int)HttpContext.Session.GetInt32("UserId");
                _context.auctions.Add(NewAuction);
                _context.SaveChanges();

                ViewBag.AllAuctions = _context.auctions.Include(a => a.User).Include(b => b.bids).ThenInclude(u => u.User).OrderBy(e => e.EndDate).ToList();

                return RedirectToAction("Dashboard");
            }
        }

//////////////// CREATE BID ////////////////

        [HttpPost]
        [Route("CreateBid/{AuctionId}")]
        public IActionResult CreateBid(int AuctionId, int BidAmount)
        {
            int CurrentUserId = (int)HttpContext.Session.GetInt32("UserId");

            Bid NewBid = new Bid()
            {
            UserId = CurrentUserId,
            AuctionId = AuctionId,
            BidAmount = BidAmount
            };
            _context.bids.Add(NewBid);
            _context.SaveChanges();

            return RedirectToAction("AuctionDetails");
        }



        


///////////////////////// DELETE /////////////////////////

        [Route("Delete/{AuctionId}")]
        public IActionResult Delete(int AuctionId)
        {
            System.Console.WriteLine("****************************");
            System.Console.WriteLine("MADE IT TO DELETE");
            System.Console.WriteLine("****************************");

            Auction AuctionToDelete = _context.auctions.SingleOrDefault(w => w.AuctionId == AuctionId);
            _context.auctions.Remove(AuctionToDelete);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }


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
