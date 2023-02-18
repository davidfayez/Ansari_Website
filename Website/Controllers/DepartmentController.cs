using Ansari_Website.Application.CPanel.Department.Commands.Create;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;
using Ansari_Website.Application.CPanel.Department.Queries.GetById;
using Ansari_Website.Domain.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
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
        //return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        if (id > 0)
        {
            ViewBag.Departments = await Mediator.Send(new GetAllDepartmentsQuery { Speciality = Speciality.Department });

            var Department = await Mediator.Send(new GetDepartmentByIdQuery
            {
                Id = id,
            });
            if (Department != null)
            {
                var result = _mapper.Map<DepartmentVM>(Department);
                return View(result);
            }
        }
        return View(new DepartmentVM());
    }
}
