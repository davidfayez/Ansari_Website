using Ansari_Website.Application.CPanel.Department.Commands.Create;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;
using Ansari_Website.Application.CPanel.Department.Queries.GetById;
using Ansari_Website.Domain.Enums;
using Ansari_Website.Infrastructure.Common;
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
    public async Task<IActionResult> IndexAsync(Speciality? type)
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;

        if (!type.HasValue)
        {
            type = Speciality.Department;
        }
        var Departments = await Mediator.Send(new GetAllDepartmentsQuery { Speciality = type });
        return View(Departments);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;

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
                result.Title = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? result.TitleEn : result.TitleAr;
                result.Description = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? result.DescriptionEn : result.DescriptionAr;
                return View(result);
            }
        }
        return View(new DepartmentVM());
    }
}
