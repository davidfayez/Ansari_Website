using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.Common.Models;
using Ansari_Website.Application.CPanel.Event.Commands.Create;
using Ansari_Website.Application.CPanel.Event.Queries.GetAll;
using Ansari_Website.Application.CPanel.Event.Queries.GetById;
using Ansari_Website.Application.CPanel.Event.VM;
using Ansari_Website.Domain.Enums;
using Ansari_Website.Infrastructure.Common;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
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
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        var Events = await Mediator.Send(new GetAllEventsQuery());
        return View(Events);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        ViewBag.Events = await Mediator.Send(new GetAllEventsQuery());

        var eventVM = new EventVM();
        if (id > 0)
        {
            var Event = await Mediator.Send(new GetEventByIdQuery
            {
                Id = id,
            });
            if (Event != null)
            {
                eventVM = _mapper.Map<EventVM>(Event);
                eventVM.Title = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? eventVM.TitleEn : eventVM.TitleAr;
                eventVM.Description = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? eventVM.DescriptionEn : eventVM.DescriptionAr;
            }
        }
        return View(eventVM);
    }

}
