using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.Common.Resources;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Application.CPanel.Doctor.Commands.Delete;
using Ansari_Website.Application.CPanel.Doctor.Queries.GetAll;
using Ansari_Website.Application.CPanel.Doctor.Queries.GetById;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ansari_Website.WebUI.Controllers;
public class DoctorController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IFileHandler _fileHandler;

    public DoctorController(IMapper mapper, IFileHandler fileHandler)
    {
        _mapper = mapper;
        _fileHandler = fileHandler;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var doctors = await Mediator.Send(new GetAllDoctorsQuery());

        return View(doctors);
    }

    [HttpGet]
    public async Task<IActionResult> CreateAsync()
    {
        var command = new CreateUpdateDoctorCommand();
        await FillDDLAsync(command);
        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateDoctorCommand command)
    {
        if (ModelState.IsValid)
        {
            var DoctorImagePath = (command.DoctorImage != null) ? /*command.DoctorCode +*/ command.DoctorImage.FileName.Substring(command.DoctorImage.FileName.LastIndexOf('.')) : null;
            if (DoctorImagePath != null)
                command.ImageUrl = DoctorImagePath;

            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                if (DoctorImagePath != null)
                    _fileHandler.UploadFile("Doctors", command.DoctorImage,"" /*command.DoctorCode.ToString()*/);
                RedirectToAction("Index");
            }
        }
        await FillDDLAsync(command);
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        var command = new CreateUpdateDoctorCommand();

        if (id > 0)
        {
            var doctor = await Mediator.Send(new GetDoctorByIdQuery
            {
                Id = id,
            });
            if (doctor != null)
            {
                command = _mapper.Map<CreateUpdateDoctorCommand>(doctor);
            }
        }
        await FillDDLAsync(command);
        return View("Create", command);
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

    private async Task FillDDLAsync(CreateUpdateDoctorCommand command)
    {
        command.Departments.Add(new SelectListItem { Text = Global.SelectOne, Value = "" });
        var Departments = await Mediator.Send(new GetAllDepartmentsQuery());
        command.Departments.AddRange(Departments.Select(a => new SelectListItem { Text = a.TitleAr, Value = a.Id.ToString() }));
    }

}
