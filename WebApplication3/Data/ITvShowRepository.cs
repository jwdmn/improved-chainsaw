namespace WebApplication3.Data
{
  public interface ITvShowRepository
  {
    SearchResult[] SearchForShow(string searchQuery);
  }
}