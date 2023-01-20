using Ansari_Website.Application.CPanel.Department.Commands.Create;
using Ansari_Website.Application.CPanel.Department.Commands.Delete;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;
using Ansari_Website.Application.CPanel.Department.Queries.GetById;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ansari_Website.WebUI.Controllers;
public class DepartmentController : BaseController
{
    private readonly IMapper _mapper;

    public DepartmentController(IMapper mapper)
    {
        _mapper = mapper;
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
    public async Task<IActionResult> CreateAsync(CreateUpdateDepartmentCommand command)
    {
        if (ModelState.IsValid)
        {
            var isSuccess = await Mediator.Send(command);
            return isSuccess ? RedirectToAction("Index") : View(command);
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
