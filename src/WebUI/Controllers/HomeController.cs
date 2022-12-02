using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
