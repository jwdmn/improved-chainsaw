using WebApplication3.Models.ViewModels;

namespace WebApplication3.Data
{
  public interface ITvShowRepository
  {
    SearchResultViewModel[] SearchForTvShow(string searchQuery);

    TvShow GetShowAndEpisodeDetailsByTvMazeId(int id);
  }
}