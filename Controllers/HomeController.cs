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
    public IActionResult NameSearch()
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
      if (name != null){
        ViewBag.Message = name;//Request["txtName"].ToString();
      } else {
        ViewBag.Message = number;
      }
      
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
