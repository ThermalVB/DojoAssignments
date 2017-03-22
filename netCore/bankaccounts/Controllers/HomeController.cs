using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using bankaccounts.Models;
using Newtonsoft.Json;

namespace bankaccounts.Controllers
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
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class HomeController : Controller
    {
        private baContext _context;
 
        public HomeController(baContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.regerrors = new List<string>();
            return View();
        }

        // POST: /Register/
        [HttpPost]
        [RouteAttribute("Register")]
        public IActionResult Register(RegViewAccount account)
        {
            if(ModelState.IsValid)
            {
                System.Console.WriteLine("Model Sucess");
                Account NewAccount = new Account
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Email = account.Email,
                    Password = account.Password,
                    Balance = account.Balance,
                };
                _context.Add(NewAccount);
                _context.SaveChanges();
                return RedirectToAction("LoginPage");
            }
            else
            {
                System.Console.WriteLine(account.FirstName);
                ViewBag.regerrors = ModelState.Values;
                return View("Index");
            }
        }

        // GET: /Home/
        [HttpGet]
        [Route("LoginPage")]
        public IActionResult LoginPage()
        {
            ViewBag.regerrors = new List<string>();
            return View("LoginPage");
        }

        // POST: /Login/
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string Email, string Password)
        {
            Account LogInAcct = _context.accounts.SingleOrDefault(account => account.Email == Email);
            
            if(LogInAcct != null && Password != null)
            {
                if ((string)LogInAcct.Password == Password)
                {
                    HttpContext.Session.SetString("FirstName", (string)LogInAcct.FirstName);
                    HttpContext.Session.SetObjectAsJson("Balance", LogInAcct.Balance);
                    return RedirectToAction("Accounts");
                }
            }
            ViewBag.logerror = "Invalid login info";
            return View("LoginPage");
        }

        // GET: /Home/
        [HttpGet]
        [Route("Accounts")]
        public IActionResult Accounts()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("FirstName");
            ViewBag.Balance = HttpContext.Session.GetObjectFromJson<double>("Balance");
            return View();
        }
        
        // Get: /LogOut/
        [HttpGet]
        [RouteAttribute("LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
