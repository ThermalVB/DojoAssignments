using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstDapper.Factory;

namespace FirstDapper.Controllers
{
     public class HomeController : Controller
    {
        private readonly UserFactory userFactory;
        public HomeController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            userFactory = new UserFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //We can call upon the methods of the userFactory directly now.
            ViewBag.Users = userFactory.FindAll();
            return View();
        }
    }
}