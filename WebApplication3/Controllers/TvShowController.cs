using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data;

namespace WebApplication3.Controllers
{
  public class TvShowController : Controller
  {
    private readonly ITvShowRepository repository;

    public TvShowController(ITvShowRepository repository)
    {
      this.repository = repository;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Search()
    {
      return View();
    }
  }
}
