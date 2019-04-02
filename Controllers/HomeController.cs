using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
  public class HomeController : Controller
  {
    PokemonModel pokemonModel = new PokemonModel();
    public IActionResult NameSearch()
    {
      return View();
    }
    public IActionResult DarkMode()
    {
      return View();
    }
    public IActionResult NumberSearch()
    {
      return View();
    }

    public IActionResult HomePage()
    {
      return View();
    }

    public IActionResult PokemonDisplay(String name = null, String number = null)
    {
      try {

        Pokemon poke = pokemonModel.GetPokemonByName(name);
        ViewData["pokemon"] = poke;

        string[] effectiveness = pokemonModel.GetPokemonEffectiveness();
        ViewData["super"] = effectiveness[0];
        ViewData["weak"] = effectiveness[1];
        ViewData["immune"] = effectiveness[2];
        
        return View();

      } catch(Exception e) {

        Console.WriteLine("*******Error*******\n"+e);
        return View("~/Views/Home/PokemonNotFound.cshtml");

      }
    }

    public IActionResult PokemonNotFound(){
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
