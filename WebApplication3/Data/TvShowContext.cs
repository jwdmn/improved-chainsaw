using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data.Entities;
using WebApplication3.Models;

namespace WebApplication3.Data
{
  public class TvShowContext : IdentityDbContext<ApplicationUser>
  {
    public TvShowContext(DbContextOptions<TvShowContext> options): base(options)
    {
    }

    public DbSet<TvShow> TvShow { get; set; }
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    public DbSet<TvShowId> TvShowId { get; set; }
  }
}
