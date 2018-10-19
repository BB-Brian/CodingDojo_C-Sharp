using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;

namespace Dojodachi.Controllers
{
    
    public class HomeController : Controller
    {
        public Random Chance = new Random();
        public bool like = true;

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            System.Console.WriteLine(like);
            if(HttpContext.Session.GetInt32("energy") == null)
            {
                HttpContext.Session.SetString("alive", "alive");
                HttpContext.Session.SetString("status", "They are fine");
                HttpContext.Session.SetInt32("happiness", 20);
                HttpContext.Session.SetInt32("fullness", 20);
                HttpContext.Session.SetInt32("energy", 50);
                HttpContext.Session.SetInt32("meals", 3);
                HttpContext.Session.SetString("message", "");
            }

            int? fullness = HttpContext.Session.GetInt32("fullness");
            int? happiness = HttpContext.Session.GetInt32("happiness");
            int? energy = HttpContext.Session.GetInt32("energy");
            int? meals = HttpContext.Session.GetInt32("meals");
            string status = HttpContext.Session.GetString("status");
            string alive = HttpContext.Session.GetString("alive");
            string message = HttpContext.Session.GetString("message");
            
            ViewBag.fullness = (int)fullness;
            ViewBag.happiness = (int)happiness;
            ViewBag.energy = (int)energy;
            ViewBag.meals = (int)meals;
            ViewBag.status = status;
            ViewBag.alive = alive;
            ViewBag.message = message;

            if(fullness == 100 && happiness == 100 && energy == 100)
            {
                HttpContext.Session.SetString("message", "Congratulations! You have Maxed out your Dachi! You win!");
            }

            if(fullness == 0)
            {
                HttpContext.Session.SetString("message", "Your Dachi starved to death.");
            }

            if(happiness == 0)
            {
                HttpContext.Session.SetString("message", "Your Dachi got sad to death.");
            }

            return View("Index");
        }

        [HttpPost]
        [Route("feed")]
        public IActionResult Feed()
        {
            int randNum = Chance.Next(5,11);
            int randLike = Chance.Next(0,4);
            int? meals = HttpContext.Session.GetInt32("meals");
            int? fullness = HttpContext.Session.GetInt32("fullness") + randNum;
            
            if(meals > 0 && randLike == 0)
            {
                like = false;
                meals --;
                HttpContext.Session.SetInt32("meals", (int)meals);
                HttpContext.Session.SetString("message", $"Your dachi didn't like your food. Fullness +0, Meals -1.");
            }

            if(meals > 0 && like == true)
            {
                meals --;
                HttpContext.Session.SetInt32("meals", (int)meals);
                HttpContext.Session.SetInt32("fullness", (int)fullness);
                HttpContext.Session.SetString("message", $"You fed your Dachi! Fullness +{randNum}, Meals -1.");
            }


            if(meals == 0)
            {
                HttpContext.Session.SetString("message", "You have no more meals!");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("play")]
        public IActionResult Play()
        {
            int randNum = Chance.Next(5,11);
            int randLike = Chance.Next(0,4);
            int? energy = HttpContext.Session.GetInt32("energy");
            
            if(randLike == 1)
            {
                like = false;
                energy -= 5;
                HttpContext.Session.SetInt32("energy", (int)energy);
                HttpContext.Session.SetString("message", $"Your Dachi didn't like how you played. Happiness +0, Energy -5.");
            }

            if(energy > 0 && like == true)
            {
                int? happiness = HttpContext.Session.GetInt32("happiness") + randNum;
                HttpContext.Session.SetInt32("happiness", (int)happiness);
                
                energy -= 5;
                HttpContext.Session.SetInt32("energy", (int)energy);

                HttpContext.Session.SetString("message", $"You played with your Dachi! Happiness +{randNum}, Energy -5.");
            }

            if(energy == 0)
            {
                HttpContext.Session.SetString("message", "You have no more energy!");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("work")]
        public IActionResult Work()
        {
            int randNum = Chance.Next(1,4);
            int? energy = HttpContext.Session.GetInt32("energy");

            if(energy > 0)
            {
                HttpContext.Session.SetString("message", $"Your Dachi worked! Meals +{randNum}, Energy -5.");
        
                energy -= 5;
                HttpContext.Session.SetInt32("energy", (int)energy);
        
                int? meals = HttpContext.Session.GetInt32("meals") + randNum;
                HttpContext.Session.SetInt32("meals", (int)meals);
                
            }
            if(energy == 0)
            {
                HttpContext.Session.SetString("message", "You have no more energy!");
            }

            return RedirectToAction("Index");
        }

        // [HttpPost]
        // [Route("sleep")]
        // public IActionResult Sleep()
        // {
        //     int randNum = Chance.Next(5,11);
        //     int? energy = HttpContext.Session.GetInt32("energy");
        //     int? happiness = HttpContext.Session.GetInt32("happiness") + randNum;
            
        //     System.Console.WriteLine(energy);
        //     System.Console.WriteLine(happiness);
        //     if(energy > 0)
        //     {
        //         energy -= 5;
        //         HttpContext.Session.SetInt32("energy", (int)energy);
        //         HttpContext.Session.SetInt32("happiness", (int)happiness);
        //         HttpContext.Session.SetString("message", $"You played with your Dachi! Happiness +{randNum}, Energy -5.");
        //     }
        //     if(energy == 0)
        //     {
        //         HttpContext.Session.SetString("message", "You have no more energy!");
        //     }

        //     return RedirectToAction("Index");
        // }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
