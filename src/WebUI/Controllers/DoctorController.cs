using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Application.CPanel.Doctor.Commands.Delete;
using Ansari_Website.Application.CPanel.Doctor.Queries.GetAll;
using Ansari_Website.Application.CPanel.Doctor.Queries.GetById;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class DoctorController : BaseController
{
    private readonly IMapper _mapper;

    public DoctorController(IMapper mapper)
    {
        _mapper = mapper;
    }


    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateUpdateDoctorCommand());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateDoctorCommand command)
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
            var doctor = await Mediator.Send(new GetDoctorByIdQuery
            {
                Id = id,
            });
            if (doctor != null)
            {
                var result = _mapper.Map<CreateUpdateDoctorCommand>(doctor);
                return RedirectToAction("Create", result);
            }
        }

        return RedirectToAction("Create", new CreateUpdateDoctorCommand());
    }

    [HttpPost]
    public async Task<JsonResult> DeleteAsync(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeleteDoctorCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    public async Task<JsonResult> GetAll()
    {
        var doctors = await Mediator.Send(new GetAllDoctorsQuery());
        return Json(doctors);
    }
}
