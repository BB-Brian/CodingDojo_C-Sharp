using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrightIdeas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BrightIdeas.Controllers
{


    public class HomeController : Controller
    {

///////////////////////// CONTEXT /////////////////////////

        private IdeasContext _context;
        public HomeController(IdeasContext context){
            _context = context;
        }
        
///////////////////////// INDEX | LOGIN | REG /////////////////////////

//////////////// INDEX ////////////////

        public IActionResult Index()
        {
            return RedirectToAction("Main");
        }

        [Route("main")]
        public IActionResult Main()
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
                User ExistingAlias = _context.users.SingleOrDefault(u => u.Alias == user.Alias);
                if(ExistingEmail != null && ExistingAlias != null)
                {
                    ViewBag.RegError = "Email and Alias already registered";
                    return View("Index");
                }
                if(ExistingAlias != null)
                {
                    ViewBag.RegError = "Alias already registered";
                    return View("Index");
                }
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
                HttpContext.Session.SetString("UserAlias",(string)user.Alias);
                HttpContext.Session.SetString("UserName",(string)user.Name);
                return RedirectToAction("BrightIdeas");
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
                        HttpContext.Session.SetString("UserAlias",(string)CurrentUser.Alias);
                        HttpContext.Session.SetString("UserName",(string)CurrentUser.Name);
                        return RedirectToAction("BrightIdeas");
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

        [Route("bright_ideas")]
        public IActionResult BrightIdeas()
        {
            if(HttpContext.Session.GetInt32("UserId") == null) {
                return RedirectToAction("Index");
            }
            else
            {
                int? UserId = HttpContext.Session.GetInt32("UserId");
                ViewBag.Error = HttpContext.Session.GetString("PostError");
                
                ViewBag.CurrentUser = _context.users.SingleOrDefault(u => u.UserId == (int)UserId);
                ViewBag.AllPosts = _context.posts.Include(p => p.User).Include(l => l.likes).OrderByDescending(i => i.likes.Count).ToList();
                ViewBag.UserId = UserId;
                ViewBag.LikeError = TempData["LikeError"];
                return View();
            }
        }
        
///////////////////////// LIKE STATUS PAGE /////////////////////////

        [Route("bright_ideas/{PostId}")]
        public IActionResult LikeStatus(int PostId)
        {
            ViewBag.PostDetails = _context.posts.Include(u => u.User).Include(l => l.likes).ThenInclude(u => u.User).SingleOrDefault(p => p.PostId == PostId);
            return View();
        }

///////////////////////// USER PROFILE PAGE /////////////////////////

        [Route("users/{UserId}")]
        public IActionResult UserProfile(int UserId)
        {
            ViewBag.User = _context.users.Include(p => p.userpostlist).Include(l => l.userlikelist).SingleOrDefault(u => u.UserId == UserId);
            return View("UserProfile");
        }

///////////////////////// FUNCTIONALITY /////////////////////////

//////////////// CREATE POST ////////////////

        [HttpPost]
        [Route("CreatePost")]
        public IActionResult CreatePost(Post NewPost)
        {
            if(NewPost.Content == null)
            {
                HttpContext.Session.SetString("PostError","Post cannot be blank");
                return RedirectToAction("BrightIdeas");
            }
            else
            {
                NewPost.UserId = (int)HttpContext.Session.GetInt32("UserId");
                _context.posts.Add(NewPost);
                _context.SaveChanges();
                return RedirectToAction("BrightIdeas");
            }
        }

//////////////// LIKE POST ////////////////

        [Route("LikePost/{PostId}")]
        public IActionResult LikePost(int PostId)
        {
            int UserId = (int)HttpContext.Session.GetInt32("UserId");     

            Like ExistingLike = _context.likes.SingleOrDefault(l => l.PostId == PostId && l.UserId == (int)UserId);

            if(ExistingLike == null)
            {
                Like NewLike = new Like()
                {
                    UserId = (int)UserId,
                    PostId = PostId
                };

                _context.likes.Add(NewLike);
                _context.SaveChanges();
                return RedirectToAction("BrightIdeas");
            }
            else
                TempData["LikeError"] = "Cannot like post more than once";
                return RedirectToAction("BrightIdeas");
        }

//////////////// DELETE ////////////////

        [Route("Delete/{PostId}")]
        public IActionResult Delete(int PostId)
        {
            Post CurrentPost = _context.posts.SingleOrDefault(p => p.PostId == PostId);
            if(CurrentPost.UserId == (int)HttpContext.Session.GetInt32("UserId"))
            {
            var DeletePost = _context.posts.SingleOrDefault(p => p.PostId == PostId);
            _context.posts.Remove(DeletePost);
            _context.SaveChanges();
            return RedirectToAction("BrightIdeas");
            }
            else
            {
                return RedirectToAction("Logout");
            }
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
