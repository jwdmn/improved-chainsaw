using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data.Entities;

namespace WebApplication3.Models
{
  public class ApplicationUser : IdentityUser
  {
    public IEnumerable<TvShow> FollowedShows { get; set; }
    public List<TvShowId> FollowedShowIds { get; set; }
  }
}
