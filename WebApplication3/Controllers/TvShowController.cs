using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Data.Entities;
using WebApplication3.Models;
using WebApplication3.Models.ViewModels;

namespace WebApplication3.Controllers
{
  public class TvShowController : Controller
  {
    private readonly ITvShowRepository repository;
    private readonly UserManager<ApplicationUser> userManager;

    public TvShowController(ITvShowRepository repository,
      UserManager<ApplicationUser> userManager)
    {
      this.repository = repository;
      this.userManager = userManager;
    }

    public IActionResult Index()
    {
      return View();
    }

    //[HttpGet]
    //public IActionResult Search(TvShowViewModel model)
    //{
    //  if (ModelState.IsValid)
    //  {
    //    var result = repository.SearchForTvShow(model.SearchQuery);
    //    model.SearchResults = result;

    //    return View(nameof(Index), model);
    //  }
    //  else
    //  {
    //    return View();
    //  }
    //}

    //[HttpPost]
    //public IActionResult Search(TvShowViewModel model)
    //{
    //  if (ModelState.IsValid)
    //  {
    //    var result = repository.SearchForTvShow(model.SearchQuery);
    //    model.SearchResults = result;

    //    return View(nameof(Index), model);
    //  }
    //  else
    //  {
    //    return View();
    //  }
    //}

    [HttpGet]
    public IActionResult Search(string searchQuery)
    {
      var result = repository.SearchForTvShow(searchQuery);

      return PartialView("SearchResult", result);
    }

    //[HttpGet]
    //[Authorize]
    //public IActionResult FollowedShows()
    //{
    //  if (this.User.Identity.IsAuthenticated)
    //  {
    //    var tmp = HttpContext.User;
    //    var user = userManager.GetUserAsync(tmp);

    //    #region endast för test
    //    ApplicationUser applicationUser = new ApplicationUser
    //    {
    //      UserName = user.Result.UserName,
    //      FollowedShows = user.Result.FollowedShows,
    //    };

    //    #endregion
    //  }

    //  return View();
    //}

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> FollowedShows()
    {
      if (this.User.Identity.IsAuthenticated)
      {
        var tmp = HttpContext.User;
        var user = await userManager.GetUserAsync(tmp);
      }

      return View();
    }

    #region fungerar nästan, men kan itne appenda tv-showen. gör nytt försök med att endast spara tvShowId på usern
    //  [Authorize]
    //  public async Task<IActionResult> FollowShow(int tvShowId)
    //  {
    //    if (ModelState.IsValid)
    //    {
    //      if (this.User.Identity.IsAuthenticated)
    //      {
    //        var tmp = HttpContext.User;
    //        var user = await userManager.GetUserAsync(tmp);
    //        var tvShow = repository.GetShowAndEpisodeDetailsByTvMazeId(tvShowId);

    //        user.FollowedShows.Append(tvShow);
    //      }
    //    }

    //    return View();
    //  }
    //}
    #endregion

    /// <summary>
    /// fungerar nästan, verkar inte spara usern persistent
    /// </summary>
    /// <param name="tvShowId"></param>
    /// <returns></returns>
    [Authorize]
    public async Task<IActionResult> FollowShow(int tvShowId)
    {
      if (ModelState.IsValid)
      {
        if (this.User.Identity.IsAuthenticated)
        {
          var tmp = HttpContext.User;
          var user = await userManager.GetUserAsync(tmp);

          user.FollowedShowIds = repository.GetUsersFollowedShowIds(user.Id);

          TvShowId tvShowToFollowId = new TvShowId(tvShowId);

          if (user.FollowedShowIds == null)
            user.FollowedShowIds = new List<TvShowId>();

          if (!user.FollowedShowIds.Contains(tvShowToFollowId))
            user.FollowedShowIds.Add(tvShowToFollowId);

          repository.SaveAll();
        }
      }

      return View(nameof(AppController.Index));
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> UnFollowShow(int tvShowId)
    {
      if (ModelState.IsValid)
      {
        if (this.User.Identity.IsAuthenticated)
        {
          var tmp = HttpContext.User;
          var user = await userManager.GetUserAsync(tmp);
          TvShowId tvShowToFollowId = new TvShowId(tvShowId);

          if (user.FollowedShowIds != null)
            if (user.FollowedShowIds.Contains(tvShowToFollowId))
              user.FollowedShowIds.RemoveAll(s => s.ShowId == tvShowToFollowId.ShowId);
        }
      }

      return View();
    }
  }
}
