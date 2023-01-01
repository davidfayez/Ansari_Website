using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.PatientRight.Commands.Create;
using Ansari_Website.Application.CPanel.PatientRight.Commands.CreateDetail;
using Ansari_Website.Application.CPanel.PatientRight.Commands.Delete;
using Ansari_Website.Application.CPanel.PatientRight.Commands.DeleteDetail;
using Ansari_Website.Application.CPanel.PatientRight.Queries.GetAll;
using Ansari_Website.Application.CPanel.PatientRight.Queries.GetAllDetails;
using Ansari_Website.Application.CPanel.PatientRight.Queries.GetById;
using Ansari_Website.Application.CPanel.PatientRight.Queries.GetDetailById;
using Ansari_Website.Application.CPanel.PatientRight.VM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class PatientRightController : BaseController
{
    private readonly IFileHandler _fileHandler;
    private readonly IMapper _mapper;

    public PatientRightController(IFileHandler fileHandler, IMapper mapper)
    {
        _fileHandler = fileHandler;
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var PatientRights = await Mediator.Send(new GetAllPatientRightsQuery());

        return View(PatientRights);
    }

    public IActionResult Create()
    {
        return View(new CreateUpdatePatientRightCommand());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdatePatientRightCommand command)
    {
        if (ModelState.IsValid)
        {
            var PatientRightImagePath = (command.PatientRightImage != null) ? /*command.PatientRightCode +*/ command.PatientRightImage.FileName.Substring(command.PatientRightImage.FileName.LastIndexOf('.')) : null;
            if (PatientRightImagePath != null)
                command.ImageUrl = PatientRightImagePath;

            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                if (PatientRightImagePath != null)
                    _fileHandler.UploadFile("PatientRights", command.PatientRightImage, "" /*command.PatientRightCode.ToString()*/);
                return RedirectToAction("Index");
            }
        }
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        var command = new CreateUpdatePatientRightCommand();

        if (id > 0)
        {
            var PatientRight = await Mediator.Send(new GetPatientRightByIdQuery
            {
                Id = id,
            });
            if (PatientRight != null)
            {
                command = _mapper.Map<CreateUpdatePatientRightCommand>(PatientRight);
            }
        }
        return View("Create", command);
    }

    [HttpPost]
    public async Task<JsonResult> DeleteDetail(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeletePatientRightDetailsByIdCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeletePatientRightCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    [HttpGet]
    public async Task<IActionResult> GetPatientRightDetailById(int id)
    {
        var command = new CreateUpdatePatientRightDetailCommand();

        if (id > 0)
        {
            var PatientRight = await Mediator.Send(new GetPatientRightDetailByIdQuery
            {
                Id = id,
            });
            if (PatientRight != null)
            {
                command = _mapper.Map<CreateUpdatePatientRightDetailCommand>(PatientRight);
            }
        }
        return PartialView("_EditPopupDetail", command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPatientRightDetailByPatientRightId(int id)
    {
        var PatientRightDetailVMs = new List<PatientRightDetailVM>();
        if (id > 0)
        {
            var PatientRightDetails = await Mediator.Send(new GetAllDetailsByPatientRightIdQuery
            {
                Id = id,
            });
            PatientRightDetailVMs = _mapper.Map<List<PatientRightDetailVM>>(PatientRightDetails);
        }
        return PartialView("_PatientRightDetailsList", PatientRightDetailVMs);
    }

    [HttpGet]
    public async Task<IActionResult> NewPatientRightDetail(int id)
    {
        return PartialView("_PopupDetail", new CreateUpdatePatientRightDetailCommand());
    }

    [HttpPost]
    public async Task<IActionResult> EditPatientRightDetail(CreateUpdatePatientRightDetailCommand command)
    {
        if (ModelState.IsValid)
        {
            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                ViewBag.IsSuccess = isSuccess;
                ViewBag.PatientRightId = command.PatientRightId;
                ViewBag.Id = command.PatientRightId;
                return PartialView("_EditPopupDetail", new CreateUpdatePatientRightDetailCommand());
            }
        }
        return PartialView("_EditPopupDetail", command);

    }
}
