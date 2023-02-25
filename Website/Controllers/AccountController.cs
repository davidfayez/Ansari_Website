using System.Security.Claims;
using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.Common.Resources;
using Ansari_Website.Application.User.Commands.Create;
using Ansari_Website.Application.User.Commands.Login;
using Ansari_Website.Application.User.Queries.GetById;
using Ansari_Website.Application.User.VM;
using Ansari_Website.Domain.Enums;
using AutoMapper;
using ERP.DAL.Domains;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Duende.IdentityServer.Models.IdentityResources;

namespace Website.Controllers;
public class AccountController : BaseController
{
    private readonly IFileHandler _fileHandler;
    private readonly IMapper _mapper;
    private readonly UserManager<AspNetUser> _userManager;
    private readonly SignInManager<AspNetUser> _signInManager;

    public AccountController(IFileHandler fileHandler, IMapper mapper,UserManager<AspNetUser> userManager,
                                    SignInManager<AspNetUser> signInManager)
    {
        _fileHandler = fileHandler;
        _mapper = mapper;
        _userManager= userManager;
        _signInManager= signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View(new LoginViaEmailCommand());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViaEmailCommand command)
    {
        if (ModelState.IsValid)
        {
            var user = await Mediator.Send(command);
            if (user != null)
            {
                await Sign(user);
                await SignIn(user, command.RememberMe);
                var z = User.Identity.IsAuthenticated;
                return RedirectToAction("Index", "Home");

            }
            else
                ModelState.AddModelError(nameof(command.Password), Global.InvalidLogin);
        }
        return View(command);
    }

    private async Task SignIn(UserVM user, bool RememberMe)
    {
        var claims = new List<Claim>
                     {
                         new Claim(ClaimTypes.Name, user.FullName ?? ""),
                         new Claim("UserId", user.Id.ToString()),
                         new Claim("Type", user.Type.ToString()),
                         new Claim(ClaimTypes.Email, user.Email.ToString()),
                         //new Claim("Avatar", user.Image)
                     };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            // Refreshing the authentication session should be allowed.

            ExpiresUtc = DateTimeOffset.UtcNow.AddYears(2),
            // The time at which the authentication ticket expires. A 
            // value set here overrides the ExpireTimeSpan option of 
            // CookieAuthenticationOptions set with AddCookie.

            IsPersistent = RememberMe,
            // Whether the authentication session is persisted across 
            // multiple requests. When used with cookies, controls
            // whether the cookie's lifetime is absolute (matching the
            // lifetime of the authentication ticket) or session-based.

            //IssuedUtc = <DateTimeOffset>,
            // The time at which the authentication ticket was issued.

            //RedirectUri = <string>
            // The full path or absolute URI to be used as an http 
            // redirect response value.
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
    }

    private async Task Sign(UserVM user)
    {
        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.FullName));
        identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));

        var principal = new ClaimsPrincipal(identity);

        var authProperties = new AuthenticationProperties
        {
            AllowRefresh = true,
            ExpiresUtc = DateTimeOffset.Now.AddDays(1),
            IsPersistent = true,
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal), authProperties);
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View(new CreateUpdateVisitorCommand() { IsNew = true });
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUpdateVisitorCommand command)
    {
        if (ModelState.IsValid)
        {
            command.IsNew = true;
            command.Type = (int)UserType.Visitor;
            var isSuccess = await Mediator.Send(command);

            if (isSuccess)
            {
                await SignIn(_mapper.Map<UserVM>(command), false);
                return RedirectToAction("Index", "Home");
            }
        }
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> Profile(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var User = await Mediator.Send(new GetUserByIdQuery
            {
                Id = id,
            });
            if (User != null)
            {
                var result = _mapper.Map<CreateUpdateUserCommand>(User);
                result.IsNew = false;
                return View(result);
            }
        }

        return View(new CreateUpdateUserCommand());
    }
}
