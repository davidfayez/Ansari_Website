using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;
using Ansari_Website.Application.CPanel.Partner.Queries.GetAll;
using Ansari_Website.Application.User.Queries.GetAll;
using Ansari_Website.Domain.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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

        ViewBag.Doctors = await Mediator.Send(new GetAllUsersQuery { Type = (int)UserType.Doctor});
        ViewBag.Departments = await Mediator.Send(new GetAllDepartmentsQuery { Speciality = Speciality.Department});
        ViewBag.Partners = await Mediator.Send(new GetAllPartnersQuery());
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

    public IActionResult Mission()
    {
        return View();
    }

    public IActionResult Overview()
    {
        return View();
    }

    public IActionResult Complaint()
    {
        return View();
    }
}
