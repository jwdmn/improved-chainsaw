using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public SearchResult[] SearchForShow(string searchQuery)
    {
      return apiHandler.SearchForShow(searchQuery);
    }
  }
}
