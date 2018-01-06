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

    public IActionResult Search(string searchQuery)
    {
      var result = repository.SearchForTvShow(searchQuery).ToList();

      if (result != null)
        return View(result);

      return View(nameof(AppController.Index));
    }

    // För ajax anrop
    //[HttpGet]
    //public IActionResult Search(string searchQuery)
    //{
    //  var result = repository.SearchForTvShow(searchQuery);

    //  return PartialView("SearchResult", result);
    //}

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> FollowedShows()
    {
      var tmp = HttpContext.User;
      var user = await userManager.GetUserAsync(tmp);
      // todo snygga till denna kod, inte dry..
      user.FollowedShowIds = repository.GetUsersFollowedShowIds(user.Id);
      List<TvShow> followedShows = new List<TvShow>();

      foreach (var show in user.FollowedShowIds)
        followedShows.Add(repository.GetShowAndEpisodeDetailsByTvMazeId(show.ShowId));

      FollowedShowsViewModel model = new FollowedShowsViewModel
      {
        User = user,
        FollowedShows = followedShows
      };

      return View(model);
    }

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

          #region dublettkontroll
          bool alreadyFollowing = false;
          foreach (var show in user.FollowedShowIds)
            if (show.ShowId == tvShowId)
              alreadyFollowing = true;

          if (!alreadyFollowing)
            user.FollowedShowIds.Add(tvShowToFollowId);
          #endregion

          repository.SaveAll();
        }
      }

      return View(nameof(AppController.Index));
    }

    [Authorize]
    public async Task<IActionResult> UnFollowShow(int tvShowId)
    {
      if (ModelState.IsValid)
      {
        if (this.User.Identity.IsAuthenticated)
        {
          var tmp = HttpContext.User;
          var user = await userManager.GetUserAsync(tmp);
          user.FollowedShowIds = repository.GetUsersFollowedShowIds(user.Id);
          TvShowId tvShowToUnfollowId = new TvShowId(tvShowId);

          bool alreadyFollowing = false;

          if (user.FollowedShowIds != null)
            foreach (var show in user.FollowedShowIds)
              if (show.ShowId == tvShowToUnfollowId.ShowId)
                alreadyFollowing = true;

          if (alreadyFollowing)
            user.FollowedShowIds.RemoveAll(x => x.ShowId == tvShowToUnfollowId.ShowId);

          repository.SaveAll();
        }
      }

      return View(nameof(AppController.Index));
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
      var result = repository.GetShowAndEpisodeDetailsByTvMazeId(id);
      return View(result);
    }
  }

}
