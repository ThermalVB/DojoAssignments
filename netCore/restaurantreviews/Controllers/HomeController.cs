using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using restaurantreviews.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace restaurantreviews.Controllers
{
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upone retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class HomeController : Controller
    {
        private rrContext _context;
 
        public HomeController(rrContext context)
        {
            _context = context;
        }
       
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        
        {
            ViewBag.adderrors = new List<string>();
            return View();
        }
        // POST: /Create/
        [HttpPost]
        [RouteAttribute("Create")]
        public IActionResult Create(Review review)
        {
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("Model Sucess");
                _context.Add(review);
                // OR _context.Users.Add(NewPerson);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            else
            {
                System.Console.WriteLine(review);
                ViewBag.adderrors = ModelState.Values;
                return View("Index");
            }
        }

        // GET: /Reviews/
        [HttpGet]
        [Route("Reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _context.reviews.ToList();
            ViewBag.AllReviews = AllReviews;
            return View("Reviews");
        }

        // GET: /Clear/
        [HttpGet]
        [Route("Clear")]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
}
