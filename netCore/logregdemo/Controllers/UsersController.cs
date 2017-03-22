using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using logregdemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace logregdemo.Controllers
{
    public class UsersController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public UsersController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.regerrors = new List<string>();
            ViewBag.logerror = "";
            return View();
        }

        // POST: /Register/
        [HttpPost]
        [RouteAttribute("Register")]
        public IActionResult Register(User user){
            if(ModelState.IsValid){
                System.Console.WriteLine("Model Sucess");
                string QueryString = $"INSERT INTO users (FirstName,LastName,Email,Password,CreatedAt) VALUES ('{user.FirstName}','{user.LastName}','{user.Email}','{user.Password}',NOW())";
                _dbConnector.Execute(QueryString);
                return RedirectToAction("Success");
            }
            else{
                ViewBag.regerrors = ModelState.Values;
                ViewBag.logerror = "";
                return View("Index");
            }
        }

        // POST: /Login/
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string Email, string Password)
        {
            string Query = $"SELECT * FROM users WHERE Email = '{Email}'";
            Dictionary<string, object> MyUser = _dbConnector.Query(Query).SingleOrDefault();
            if(MyUser != null && Password != null)
            {
                if ((string)MyUser["Password"] == Password)
                {
                    return RedirectToAction("Success");
                }
            }
            ViewBag.logerror = "Invalid login info";
            ViewBag.regerrors = new List<string>();
            return View("Index");
        }

        // GET: /Home/
        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
