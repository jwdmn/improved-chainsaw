using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models.ViewModels;

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

    [HttpGet]
    public IActionResult Search(TvShowViewModel model)
    {
      if (ModelState.IsValid)
      {
        var result = repository.SearchForShow(model.SearchQuery);
        model.SearchResults = result;

        return View(nameof(Index), model);
      }
      else
      {
        return View();
      }
    }
  }
}
