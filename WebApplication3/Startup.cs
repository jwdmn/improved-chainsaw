using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication3.Data;
using WebApplication3.Data.Entities;
using WebApplication3.Models;

namespace WebApplication3
{
  public class Startup
  {
    private readonly IConfiguration config;

    public Startup(IConfiguration config)
    {
      this.config = config;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddIdentity<ApplicationUser, IdentityRole>(cfg =>
      {
        cfg.User.RequireUniqueEmail = true;
      })
        .AddEntityFrameworkStores<TvShowContext>();

      services.AddAuthentication(); // kanske bort?

      services.AddAutoMapper();

      services.AddDbContext<TvShowContext>(cfg =>
       {
         cfg.UseSqlServer(config.GetConnectionString("TvConnectionString"));
       });

      services.AddScoped<ApiHandler>();

      services.AddScoped<ITvShowRepository, TvShowRepository>();

      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }


      app.UseStaticFiles();

      app.UseAuthentication();

      app.UseMvc(cfg =>
      {
        cfg.MapRoute("Default",
          "{controller}/{action}/{id?}",
          new { controller = "App", Action = "Index" });
      });
    }
  }
}
