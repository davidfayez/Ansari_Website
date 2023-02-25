using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.AboutUs.Commands.Create;
using Ansari_Website.Application.CPanel.AboutUs.Queries.GetById;
using Ansari_Website.Application.CPanel.Complaint.Commands.Create;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;
using Ansari_Website.Application.CPanel.OverView.Queries.GetAll;
using Ansari_Website.Application.CPanel.Partner.Queries.GetAll;
using Ansari_Website.Application.CPanel.Question.Queries.GetAll;
using Ansari_Website.Application.CPanel.Survey.Commands.Create;
using Ansari_Website.Application.CPanel.SurveyQuestion.Queries.GetAll;
using Ansari_Website.Application.User.Queries.GetAll;
using Ansari_Website.Domain.Enums;
using Ansari_Website.Infrastructure.Common;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Website.Controllers;
public class HomeController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IFileHandler _fileHandler;
    private readonly IWebHostEnvironment _environment;


    public HomeController(IMapper mapper, IFileHandler fileHandler, IWebHostEnvironment environment)
    {
        _mapper = mapper;
        _fileHandler = fileHandler;
        _environment = environment;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var mainFolderPath = Path.Combine(_environment.WebRootPath, "images");
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        ViewBag.Doctors = await Mediator.Send(new GetAllUsersQuery { Type = (int)UserType.Doctor});
        ViewBag.Departments = await Mediator.Send(new GetAllDepartmentsQuery { LangId = Request.GetLangIdFromHeader(), Speciality = Speciality.Department});
        ViewBag.Partners = await Mediator.Send(new GetAllPartnersQuery { LangId = Request.GetLangIdFromHeader()});
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public async Task<IActionResult> Mission()
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        var OverView = await Mediator.Send(new GetAllOverViewsQuery { LangId = Request.GetLangIdFromHeader() });
        return View(OverView);
    }

    public async Task<IActionResult> Overview()
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        var AboutUs = await Mediator.Send(new GetAboutUsQuery());
        var command = _mapper.Map<CreateUpdateAboutUsCommand>(AboutUs);
        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> ComplaintAsync(CreateComplaintCommand command)
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        var isSuccess = await Mediator.Send(command);
        ViewBag.IsSuccess = isSuccess;
        return Json(isSuccess);
    }


    public async Task<IActionResult> Survey()
    {
        ViewBag.IsArabic =  Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        ViewBag.Questions = await Mediator.Send(new GetAllQuestionsQuery());
        return PartialView("_SurveyForm", new CreateUpdateSurveyCommand());
    }

    [HttpPost]
    public async Task<IActionResult> Survey(CreateUpdateSurveyCommand command)
    {
        var isSuccess = await Mediator.Send(command);
        ViewBag.IsSuccess = isSuccess;
        return Json(isSuccess);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult ChangeLanguage(string Lang)
    {
        if (Lang != null)
        {
            Response.Cookies.Append(
             CookieRequestCultureProvider.DefaultCookieName,
             CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(Lang)),
             new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            //var currentLanguage = HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
            //var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            //AppSession.IsArabic = Lang == "ar-EG" ? true : false; //rqf.RequestCulture.Culture.TextInfo.IsRightToLeft;
        }
        return Redirect(Request.Headers["Referer"].ToString());
    }

}
