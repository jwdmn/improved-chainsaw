using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data.Entities;

namespace WebApplication3.Models.ViewModels
{
  public class FollowedShowsViewModel : IEnumerable
  {
    public ApplicationUser User { get; set; }
    public TvShow[] FollowedShows { get; set; }

    public IEnumerator GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}
