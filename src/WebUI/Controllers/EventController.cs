using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Application.CPanel.Event.Commands.Create;
using Ansari_Website.Application.CPanel.Event.Commands.CreateDetail;
using Ansari_Website.Application.CPanel.Event.Commands.Delete;
using Ansari_Website.Application.CPanel.Event.Commands.DeleteDetail;
using Ansari_Website.Application.CPanel.Event.Queries.GetAll;
using Ansari_Website.Application.CPanel.Event.Queries.GetAllDetails;
using Ansari_Website.Application.CPanel.Event.Queries.GetById;
using Ansari_Website.Application.CPanel.Event.Queries.GetDetailById;
using Ansari_Website.Application.CPanel.Event.VM;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class EventController : BaseController
{
    private readonly IFileHandler _fileHandler;
    private readonly IMapper _mapper;

    public EventController(IFileHandler fileHandler, IMapper mapper)
    {
        _fileHandler = fileHandler;
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var Events = await Mediator.Send(new GetAllEventsQuery());

        return View(Events);
    }

    public IActionResult Create()
    {
        return View(new CreateUpdateEventCommand());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateEventCommand command)
    {
        if (ModelState.IsValid)
        {
            var EventImagePath = (command.EventImage != null) ? command.TitleEn + command.EventImage.FileName.Substring(command.EventImage.FileName.LastIndexOf('.')) : null;
            if (EventImagePath != null)
                command.ImageUrl = EventImagePath;

            foreach (var detail in command.EventDetailVMs)
            {
                foreach (var image in detail.EventDetailImages)
                {
                    var eventDetailImagePath = (image != null) ? detail.TitleEn.ToString() + image.FileName : null;
                    if (eventDetailImagePath != null)
                        detail.ImageUrls = string.Concat(detail.ImageUrls, ",", eventDetailImagePath);
                }

            }

            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                if (EventImagePath != null)
                    _fileHandler.UploadFile("Events", command.EventImage,command.TitleEn.ToString());

                foreach (var detail in command.EventDetailVMs)
                {
                    foreach (var image in detail.EventDetailImages)
                    {
                        var eventDetailImagePath = (image != null) ? detail.TitleEn.ToString() + image.FileName : null;
                        if (eventDetailImagePath != null)
                            _fileHandler.UploadFile("Events", image, (detail.TitleEn.ToString()) + image.FileName);
                    }
                    
                }
                return RedirectToAction("Index");
            }
        }
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        var command = new CreateUpdateEventCommand();

        if (id > 0)
        {
            var Event = await Mediator.Send(new GetEventByIdQuery
            {
                Id = id,
            });
            if (Event != null)
            {
                command = _mapper.Map<CreateUpdateEventCommand>(Event);
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
              new DeleteEventDetailsByIdCommand
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
              new DeleteEventCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    [HttpGet]
    public async Task<IActionResult> GetEventDetailById(int id)
    {
        var command = new CreateUpdateEventDetailCommand();

        if (id > 0)
        {
            var Event = await Mediator.Send(new GetEventDetailByIdQuery
            {
                Id = id,
            });
            if (Event != null)
            {
                command = _mapper.Map<CreateUpdateEventDetailCommand>(Event);
            }
        }
        return PartialView("_EditPopupDetail", command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEventDetailByEventId(int id)
    {
        var EventDetailVMs = new List<EventDetailVM>();
        if (id > 0)
        {
            var EventDetails = await Mediator.Send(new GetAllDetailsByEventIdQuery
            {
                Id = id,
            });
            EventDetailVMs = _mapper.Map<List<EventDetailVM>>(EventDetails);
        }
        return PartialView("_EventDetailsList", EventDetailVMs);
    }

    [HttpGet]
    public async Task<IActionResult> NewEventDetail(int id)
    {

        return PartialView("_PopupDetail", new CreateUpdateEventDetailCommand());
    }

    [HttpPost]
    public async Task<IActionResult> EditEventDetail(CreateUpdateEventDetailCommand command)
    {
        if (ModelState.IsValid)
        {
            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                ViewBag.IsSuccess = isSuccess;
                ViewBag.EventId = command.EventId;
                ViewBag.Id = command.EventId;
                return PartialView("_EditPopupDetail", new CreateUpdateEventDetailCommand());
            }
        }
        return PartialView("_EditPopupDetail", command);

    }
}
