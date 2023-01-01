using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Application.CPanel.OverView.Commands.Create;
using Ansari_Website.Application.CPanel.OverView.Commands.CreateDetail;
using Ansari_Website.Application.CPanel.OverView.Commands.Delete;
using Ansari_Website.Application.CPanel.OverView.Commands.DeleteDetail;
using Ansari_Website.Application.CPanel.OverView.Queries.GetAll;
using Ansari_Website.Application.CPanel.OverView.Queries.GetAllDetails;
using Ansari_Website.Application.CPanel.OverView.Queries.GetById;
using Ansari_Website.Application.CPanel.OverView.Queries.GetDetailById;
using Ansari_Website.Application.CPanel.OverView.VM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class OverViewController : BaseController
{
    private readonly IFileHandler _fileHandler;
    private readonly IMapper _mapper;

    public OverViewController(IFileHandler fileHandler, IMapper mapper)
    {
        _fileHandler = fileHandler;
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var OverViews = await Mediator.Send(new GetAllOverViewsQuery());

        return View(OverViews);
    }

    public IActionResult Create()
    {
        return View(new CreateUpdateOverViewCommand());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateOverViewCommand command)
    {
        if (ModelState.IsValid)
        {
            var OverViewImagePath = (command.OverViewImage != null) ? /*command.OverViewCode +*/ command.OverViewImage.FileName.Substring(command.OverViewImage.FileName.LastIndexOf('.')) : null;
            if (OverViewImagePath != null)
                command.ImageUrl = OverViewImagePath;

            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                if (OverViewImagePath != null)
                    _fileHandler.UploadFile("OverViews", command.OverViewImage, "" /*command.OverViewCode.ToString()*/);
                return RedirectToAction("Index");
            }
        }
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        var command = new CreateUpdateOverViewCommand();

        if (id > 0)
        {
            var OverView = await Mediator.Send(new GetOverViewByIdQuery
            {
                Id = id,
            });
            if (OverView != null)
            {
                command = _mapper.Map<CreateUpdateOverViewCommand>(OverView);
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
              new DeleteOverViewDetailsByIdCommand
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
              new DeleteOverViewCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    [HttpGet]
    public async Task<IActionResult> GetOverViewDetailById(int id)
    {
        var command = new CreateUpdateOverViewDetailCommand();

        if (id > 0)
        {
            var OverView = await Mediator.Send(new GetOverViewDetailByIdQuery
            {
                Id = id,
            });
            if (OverView != null)
            {
                command = _mapper.Map<CreateUpdateOverViewDetailCommand>(OverView);
            }
        }
        return PartialView("_EditPopupDetail", command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOverViewDetailByOverViewId(int id)
    {
        var OverViewDetailVMs = new List<OverViewDetailVM>();
        if (id > 0)
        {
            var OverViewDetails = await Mediator.Send(new GetAllDetailsByOverViewIdQuery
            {
                Id = id,
            });
            OverViewDetailVMs = _mapper.Map<List<OverViewDetailVM>>(OverViewDetails);
        }
        return PartialView("_OverViewDetailsList", OverViewDetailVMs);
    }

    [HttpGet]
    public async Task<IActionResult> NewOverViewDetail(int id)
    {

        return PartialView("_PopupDetail", new CreateUpdateOverViewDetailCommand());
    }

    [HttpPost]
    public async Task<IActionResult> EditOverViewDetail(CreateUpdateOverViewDetailCommand command)
    {
        if (ModelState.IsValid)
        {
            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                ViewBag.IsSuccess = isSuccess;
                ViewBag.OverViewId = command.OverViewId;
                ViewBag.Id = command.OverViewId;
                return PartialView("_EditPopupDetail", new CreateUpdateOverViewDetailCommand());
            }
        }
        return PartialView("_EditPopupDetail", command);

    }

}
