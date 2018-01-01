using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Data.Entities
{
  public class TvShowId
  {
    public TvShowId()
    {

    }

    public TvShowId(int tvShowId)
    {
      ShowId = tvShowId;
    }

    public int Id { get; set; }
    public int ShowId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
  }
}
