// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;

namespace MyDotnetWebApp.Controllers
{
  public class HomeController : Controller
  {
    // This action returns the default view.
    public IActionResult Index()
    {
      return View();
    }

    // An additional action to demonstrate passing data to a view.
    public IActionResult About()
    {
      ViewData["Message"] = "Welcome to your MVC application using ASP.NET Core!";
      return View();
    }
  }
}
