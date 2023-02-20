using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.Common.Models;
using Ansari_Website.Application.CPanel.Department.Commands.Create;
using Ansari_Website.Application.CPanel.Department.Commands.Delete;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;
using Ansari_Website.Application.CPanel.Department.Queries.GetById;
using Ansari_Website.Application.CPanel.Department.Queries.GetByType;
using Ansari_Website.Domain.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ansari_Website.WebUI.Controllers;
public class DepartmentController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IFileHandler _fileHandler;

    public DepartmentController(IMapper mapper, IFileHandler fileHandler)
    {
        _mapper = mapper;
        _fileHandler = fileHandler;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var Departments = await Mediator.Send(new GetAllDepartmentsQuery());

        return View(Departments);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateUpdateDepartmentCommand());
    }

    [HttpPost]
    public async Task<IActionResult> FilterAsync(Speciality type)
    {
        if (type > 0)
        {
            var Departments = await Mediator.Send(new GetDepartmentByTypeQuery
            {
                Type = type,
            });
            if (Departments != null)
            {
                var result = _mapper.Map<List<DepartmentVM>>(Departments);
                return PartialView("_DepartmentsList", result);
            }
        }
        var AllDepartments = await Mediator.Send(new GetAllDepartmentsQuery());
        return PartialView("_DepartmentsList", AllDepartments);

    }
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateDepartmentCommand command)
    {
        if (ModelState.IsValid)
        {
            var DepartmentImage = (command.DepartmentImage != null) ? command.DepartmentImage.FileName : null;

            if (DepartmentImage != null)
                command.ImageUrl = DepartmentImage;

            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                if (DepartmentImage != null)
                {
                    var mainFolderPath = "E:\\Private\\Ansari_Website\\Website\\wwwroot\\images";
                    _fileHandler.UploadFile("Departments", command.DepartmentImage);
                    _fileHandler.UploadFile("Departments", command.DepartmentImage, mainFolderPath);
                }
                return RedirectToAction("Index");
            }
        }
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        if (id > 0)
        {
            var Department = await Mediator.Send(new GetDepartmentByIdQuery
            {
                Id = id,
            });
            if (Department != null)
            {
                var result = _mapper.Map<CreateUpdateDepartmentCommand>(Department);
                return View("Create",result);
            }
        }

        return View("Create",new CreateUpdateDepartmentCommand());
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeleteDepartmentCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    public async Task<JsonResult> GetAll()
    {
        var Departments = await Mediator.Send(new GetAllDepartmentsQuery());
        return Json(Departments);
    }
}
