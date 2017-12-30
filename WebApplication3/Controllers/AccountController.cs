using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Data.Entities;
using WebApplication3.Models.ViewModels;

namespace WebApplication3.Controllers
{
  public class AccountController : Controller
  {
    private readonly ILogger<AccountController> logger;
    private readonly SignInManager<AppUser> signInManager;
    private readonly UserManager<AppUser> userManager;
    private readonly IConfiguration config;

    public AccountController(ILogger<AccountController> logger,
      SignInManager<AppUser> signInManager,
      UserManager<AppUser> userManager,
      IConfiguration config)
    {
      this.logger = logger;
      this.signInManager = signInManager;
      this.userManager = userManager;
      this.config = config;
    }

    public IActionResult Login()
    {
      if (this.User.Identity.IsAuthenticated)
      {
        return RedirectToAction("Index", "App");
      }

      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
      if (ModelState.IsValid)
      {
        var result = await signInManager.PasswordSignInAsync(model.Username,
          model.Password,
          model.RememberMe,
          false);

        if (result.Succeeded)
        {
          if (Request.Query.Keys.Contains("ReturnUrl"))
          {
            return Redirect(Request.Query["ReturnUrl"].First());
          }
          else
          {
            return RedirectToAction("Index", "App");
          }
        }
      }

      ModelState.AddModelError("", "Failed to login");

      return View();
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
      await signInManager.SignOutAsync();
      return RedirectToAction("Index", "App");
    }
  }
}
