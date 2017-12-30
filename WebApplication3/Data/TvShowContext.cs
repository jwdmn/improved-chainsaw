using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data.Entities;

namespace WebApplication3.Data
{
  public class TvShowContext : IdentityDbContext<AppUser>
  {
    public TvShowContext(DbContextOptions<TvShowContext> options): base(options)
    {
    }

    public DbSet<TvShow> TvShow { get; set; }
  }
}
