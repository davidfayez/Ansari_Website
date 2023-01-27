using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
public class HomeController : BaseController
{
    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Mission()
    {
        return View();
    }

    public IActionResult Overview()
    {
        return View();
    }
}
