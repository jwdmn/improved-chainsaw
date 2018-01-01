using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data.Entities;

namespace WebApplication3.Data.Entities
{
  public class ApplicationUser : IdentityUser
  {
    public ApplicationUser()
    {

    }

    public List<TvShowId> FollowedShowIds { get; set; }
  }
}
