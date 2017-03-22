using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;

namespace quotingdojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("/quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> allQuotes = DbConnector.Query("SELECT * FROM quotes JOIN users ON users.id = quotes.users_id");
            return View(allQuotes);
        }
    }
}
