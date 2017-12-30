using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication3.Data
{
  public class TvShowContext : DbContext
  {
    public DbSet<TvShow> TvShow { get; set; }
  }
}
