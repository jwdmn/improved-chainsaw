using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data;

namespace WebApplication3.Controllers
{
  public class AppController : Controller
  {
    private readonly ITvShowRepository repository;

    public AppController(ITvShowRepository repository)
    {
      this.repository = repository;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult About()
    {
      ViewBag.Title = "About Us";

      return View();
    }
  }
}
