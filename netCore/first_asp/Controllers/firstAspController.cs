using Microsoft.AspNetCore.Mvc;

namespace firstAsp.Controllers
{
    public class firstAspController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

