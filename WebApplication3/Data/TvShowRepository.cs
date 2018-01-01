using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data.Entities;
using WebApplication3.Models.ViewModels;

namespace WebApplication3.Data
{
  public class TvShowRepository : ITvShowRepository
  {
    private readonly TvShowContext ctx;
    private readonly ApiHandler apiHandler;

    public TvShowRepository(TvShowContext ctx, ApiHandler apiHandler)
    {
      this.ctx = ctx;
      this.apiHandler = apiHandler;
    }

    public TvShow GetShowAndEpisodeDetailsByTvMazeId(int id)
    {
      return apiHandler.GetTvShowAndEpisodeDetails(id);

    }

    public SearchResultViewModel[] SearchForTvShow(string searchQuery)
    {
      return apiHandler.SearchForShow(searchQuery);
    }

    public bool SaveAll()
    {
      return ctx.SaveChanges() > 0;
    }

    public List<TvShowId> GetUsersFollowedShowIds(string applicationUserId)
    {
      var result = ctx.TvShowId
        .Where(x => x.ApplicationUser.Id == applicationUserId)
        .ToList();

      return result;
    }
  }
}
