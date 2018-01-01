using System.Collections.Generic;
using WebApplication3.Data.Entities;
using WebApplication3.Models.ViewModels;

namespace WebApplication3.Data
{
  public interface ITvShowRepository
  {
    SearchResultViewModel[] SearchForTvShow(string searchQuery);

    TvShow GetShowAndEpisodeDetailsByTvMazeId(int id);
    bool SaveAll();
    List<TvShowId> GetUsersFollowedShowIds(string applicationUserId);
  }
}