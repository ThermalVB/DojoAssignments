using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dojosurvey.Controllers
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

        [HttpPost]
        [Route("result")]
        public IActionResult Result(string name, string language, string location, string comment)
        {
            ViewBag.name = name;
            ViewBag.language = language;
            ViewBag.location = location;
            ViewBag.comment = comment;
            return View("Result");
        }
    }
}
