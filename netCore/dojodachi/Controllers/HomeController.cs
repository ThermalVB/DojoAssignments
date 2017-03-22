using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace dojodachi.Controllers
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class HomeController : Controller
    {
            [HttpGet]
            [Route("")]
            public IActionResult Index()
            {
                if(HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi") == null)
                {
                    HttpContext.Session.SetObjectAsJson("Dojodachi", new Dojodachi());
                }

                ViewBag.Dojodachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
                ViewBag.Message = "You got a brand new Dojodachi!";
                ViewBag.GameStatus = "running";
                ViewBag.Reaction = "";
                return View();
            }

            [HttpPost]
            [Route("performAction")]
            public IActionResult PerformAction(string action)
            {
                Dojodachi EditDachi = HttpContext.Session.GetObjectFromJson<Dojodachi>("Dojodachi");
                Random RandObject = new Random();
                ViewBag.GameStatus = "running";
                switch(action)
                {
                    case "feed":
                        if(EditDachi.Meals > 0){
                            EditDachi.Meals -= 1;
                            if(RandObject.Next(0, 4) > 0)
                            {
                                EditDachi.Fullness += RandObject.Next(5, 11);
                                ViewBag.Reaction = ":)";
                                ViewBag.Message = "Dojodachi enjoyed the meal!";
                            }
                            else
                            {
                                ViewBag.Reaction = ":(";
                                ViewBag.Message = "Dojodachi didn't like the food very much...";
                            }
                        }
                        else
                        {
                            ViewBag.Reaction = ":(";
                            ViewBag.Message = "You don't have any food for your Dojodachi!";
                        }
                        break;
                    case "play":
                        if(EditDachi.Energy > 4)
                        {
                            EditDachi.Energy -= 5;
                            if(RandObject.Next(0, 4) > 0)
                            {
                                EditDachi.Happiness += RandObject.Next(5, 11);
                                ViewBag.Reaction = ":)";
                                ViewBag.Message = "Dojodachi had fun playing!";
                            }
                            else
                            {
                                ViewBag.Reaction = ":(";
                                ViewBag.Message = "Looks like Dojodachi didn't want to play...";
                            }
                        }
                        else
                        {
                            ViewBag.Reaction = ":(";
                            ViewBag.Message = "Not enough energy...";
                        }

                        break;
                    case "work":
                        if(EditDachi.Energy > 4)
                        {
                            EditDachi.Energy -= 5;
                            EditDachi.Meals += RandObject.Next(1, 4);
                            ViewBag.Reaction = ":)";
                            ViewBag.Message = "You worked hard to feed your Dojodachi!";
                        }
                        else
                        {
                            ViewBag.Reaction = ":(";
                            ViewBag.Message = "Not enough energy...";
                        }
                        break;
                    case "sleep":
                        EditDachi.Energy += 15;
                        EditDachi.Fullness -= 5;
                        EditDachi.Happiness -= 5;
                        ViewBag.Reaction = ":)";
                        ViewBag.Message = "Dojodachi seems well rested.";
                        break;
                    default:
                        // Handle unxpected values submitted from form
                        ViewBag.Reaction = "XXXXXXXXXXXXXX";
                        ViewBag.Message = "There's a glitch in the martix...";
                        break;

                }
                if(EditDachi.Fullness < 1 || EditDachi.Happiness < 1)
                {
                    ViewBag.Reaction = "X(";
                    ViewBag.Message = "Oh no! Your Dojodachi has died...";
                    ViewBag.GameStatus = "over";
                }
                else if(EditDachi.Fullness > 99 && EditDachi.Happiness > 99)
                {
                    ViewBag.Reaction = ":D";
                    ViewBag.Message = "Congratulations! You win!";
                    ViewBag.GameStatus = "over";
                }
                HttpContext.Session.SetObjectAsJson("Dojodachi", EditDachi);
                ViewBag.Dojodachi = EditDachi;
                return View("Index");
            }

            [HttpGet]
            [Route("reset")]
            public IActionResult Reset()
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }
        }
    }
