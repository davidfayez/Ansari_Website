using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.Offer.Commands.Create;
using Ansari_Website.Application.CPanel.Offer.Queries.GetById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Application.CPanel.Doctor.Commands.Delete;
using Ansari_Website.Application.CPanel.Offer.Commands.Delete;
using Ansari_Website.Application.CPanel.Answer.Queries.GetAll;
using Ansari_Website.Application.CPanel.Offer.Queries.GetAll;
using Ansari_Website.Domain.Entities.CPanel;
using Ansari_Website.Application.CPanel.OfferDetail.Queries.GetById;
using Ansari_Website.Application.CPanel.Question.Commands.Delete;

namespace Ansari_Website.WebUI.Controllers;
public class OfferController : BaseController
{
    private readonly IFileHandler _fileHandler;
    private readonly IMapper _mapper;

    public OfferController(IFileHandler fileHandler, IMapper mapper)
    {
        _fileHandler = fileHandler;
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var Offers = await Mediator.Send(new GetAllOffersQuery());

        return View(Offers);
    }

    public IActionResult Create()
    {
        return View(new CreateUpdateOfferCommand());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateOfferCommand command)
    {
        if (ModelState.IsValid)
        {
            var OfferImagePath = (command.OfferImage != null) ? /*command.OfferCode +*/ command.OfferImage.FileName.Substring(command.OfferImage.FileName.LastIndexOf('.')) : null;
            if (OfferImagePath != null)
                command.ImageUrl = OfferImagePath;

            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                if (OfferImagePath != null)
                    _fileHandler.UploadFile("Offers", command.OfferImage, "" /*command.OfferCode.ToString()*/);
                return RedirectToAction("Index");
            }
        }
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        var command = new CreateUpdateOfferCommand();

        if (id > 0)
        {
            var Offer = await Mediator.Send(new GetOfferByIdQuery
            {
                Id = id,
            });
            if (Offer != null)
            {
                command = _mapper.Map<CreateUpdateOfferCommand>(Offer);
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
              new DeleteOfferDetailsByIdCommand
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
              new DeleteOfferCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    [HttpGet]
    public async Task<IActionResult> GetOfferDetailById(int id)
    {
        var command = new CreateUpdateOfferDetailCommand();

        if (id > 0)
        {
            var Offer = await Mediator.Send(new GetOfferDetailByIdQuery
            {
                Id = id,
            });
            if (Offer != null)
            {
                command = _mapper.Map<CreateUpdateOfferDetailCommand>(Offer);
            }
        }
        return PartialView("_EditPopupDetail", command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOfferDetailByOfferId(int id)
    {
        var OfferDetailVMs = new List<OfferDetailVM>();
        if (id > 0)
        {
            var OfferDetails = await Mediator.Send(new GetAllDetailsByOfferIdQuery
            {
                Id = id,
            });
           OfferDetailVMs = _mapper.Map<List<OfferDetailVM>>(OfferDetails);
        }
        return PartialView("_OfferDetailsList", OfferDetailVMs);
    }

    [HttpGet]
    public async Task<IActionResult> NewOfferDetail(int id)
    {
        
        return PartialView("_PopupDetail", new CreateUpdateOfferDetailCommand());
    }
    
    [HttpPost]
    public async Task<IActionResult> EditOfferDetail(CreateUpdateOfferDetailCommand command)
    {
        if (ModelState.IsValid)
        {
            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                ViewBag.IsSuccess = isSuccess;
                ViewBag.OfferId = command.OfferId;
                ViewBag.Id = command.OfferId;
                return PartialView("_EditPopupDetail", new CreateUpdateOfferDetailCommand());
            }
        }
        return PartialView("_EditPopupDetail", command);

    }
}
