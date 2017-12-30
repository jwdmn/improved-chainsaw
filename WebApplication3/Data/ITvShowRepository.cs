using WebApplication3.Models.ViewModels;

namespace WebApplication3.Data
{
  public interface ITvShowRepository
  {
    SearchResultViewModel[] SearchForShow(string searchQuery);
  }
}