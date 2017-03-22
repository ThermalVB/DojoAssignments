using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pokeapiv2.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("pokeinfo/{id}")]
        public IActionResult GetInfo(int id)
        {
            var PokeObject = new Pokemon();

            WebRequest.GetPokemonDataAsync(id, PokeResponse => {
                PokeObject = PokeResponse;
            }).Wait();
            ViewBag.Pokemon = PokeObject;
            return View();
        }
    }
}
