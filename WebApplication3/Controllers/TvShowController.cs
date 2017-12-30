using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
  public class TvShowController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
