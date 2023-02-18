using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.AboutUs.Commands.Create;
using Ansari_Website.Application.CPanel.AboutUs.Commands.DeleteOurValue;
using Ansari_Website.Application.CPanel.AboutUs.Queries.GetAll;
using Ansari_Website.Application.CPanel.AboutUs.Queries.GetAllOurValues;
using Ansari_Website.Application.CPanel.AboutUs.Queries.GetById;
using Ansari_Website.Application.CPanel.AboutUs.Queries.GetOurValueById;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Application.CPanel.Offer.Commands.Create;
using Ansari_Website.Application.CPanel.Offer.Commands.Delete;
using Ansari_Website.Application.CPanel.Offer.Queries.GetAll;
using Ansari_Website.Application.CPanel.OfferDetail.Queries.GetById;
using Ansari_Website.Application.CPanel.SiteInfo.Commands.Create;
using Ansari_Website.Application.CPanel.SiteInfo.Queries.GetById;
using Ansari_Website.Domain.Entities.CPanel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class CPanelLookupsController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IFileHandler _fileHandler;

    public CPanelLookupsController(IMapper mapper, IFileHandler fileHandler)
    {
        _mapper = mapper;
        _fileHandler = fileHandler;
    }

    #region Site Info
    [HttpGet]
    public async Task<IActionResult> SiteInfoAsync()
    {
        var SiteInfo = await Mediator.Send(new GetSiteInfoQuery());
        var command = _mapper.Map<CreateUpdateSiteInfoCommand>(SiteInfo);
        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> SiteInfoAsync(CreateUpdateSiteInfoCommand command)
    {
        var isSuccesfully = await Mediator.Send(command);
        ViewBag.isSuccesfully = isSuccesfully;
        return View(command);
    }

    #endregion

    #region AboutUs
    [HttpGet]
    public async Task<IActionResult> AboutUsAsync()
    {
        var AboutUs = await Mediator.Send(new GetAboutUsQuery());
        var command = _mapper.Map<CreateUpdateAboutUsCommand>(AboutUs);
        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> AboutUsAsync(CreateUpdateAboutUsCommand command)
    {
        if (ModelState.IsValid)
        {
            var OfferImagePath = (command.AboutUsImage != null) ? /*command.OfferCode +*/ command.AboutUsImage.FileName.Substring(command.AboutUsImage.FileName.LastIndexOf('.')) : null;
            if (OfferImagePath != null)
                command.ImageUrl = OfferImagePath;

            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                if (OfferImagePath != null)
                    _fileHandler.UploadFile("AboutUs", command.AboutUsImage, "" /*command.OfferCode.ToString()*/);
                return RedirectToAction(nameof(AboutUs));
            }
        }
        return View(command);
    }

    [HttpPost]
    public async Task<JsonResult> DeleteOurValue(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeleteOurValueByIdCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }


    //[HttpGet]
    public async Task<IActionResult> GetOurValueById(int id)
    {
        var command = new CreateUpdateOurValueCommand();

        if (id > 0)
        {
            var OurValue = await Mediator.Send(new GetOurValueByIdQuery
            {
                Id = id,
            });
            if (OurValue != null)
            {
                command = _mapper.Map<CreateUpdateOurValueCommand>(OurValue);
            }
        }
        return PartialView("_EditPopupDetail", command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOurValuesByAboutUsId(int id)
    {
        var OurValueVMs = new List<OurValueVM>();
        if (id > 0)
        {
            var OurValues = await Mediator.Send(new GetAllOurValuesByAboutUsIdQuery
            {
                Id = id,
            });
            OurValueVMs = _mapper.Map<List<OurValueVM>>(OurValues);
        }
        return PartialView("_OurValuesList", OurValueVMs);
    }

    [HttpGet]
    public async Task<IActionResult> NewOurValue(int id)
    {

        return PartialView("_PopupDetail", new CreateUpdateOurValueCommand());
    }

    [HttpPost]
    public async Task<IActionResult> EditOurValue(CreateUpdateOurValueCommand command)
    {
        if (ModelState.IsValid)
        {
            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                ViewBag.IsSuccess = isSuccess;
                ViewBag.AboutUsId = command.AboutUsId;
                ViewBag.Id = command.AboutUsId;
                return PartialView("_EditPopupDetail", new CreateUpdateOurValueCommand());
            }
        }
        return PartialView("_EditPopupDetail", command);

    }
    #endregion

    #region Setting

    [HttpGet]
    public IActionResult Setting()
    {
        return View();
    }
    #endregion
}
