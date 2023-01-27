using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
public class AccountController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
}
