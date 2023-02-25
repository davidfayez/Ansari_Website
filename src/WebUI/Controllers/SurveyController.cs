using Ansari_Website.Application.CPanel.Complaint.Commands.IsSeen;
using Ansari_Website.Application.CPanel.Complaint.Queries.GetAll;
using Ansari_Website.Application.CPanel.Complaint.Queries.GetById;
using Ansari_Website.Application.CPanel.Survey.Commands.View;
using Ansari_Website.Application.CPanel.Survey.Queries.GetAll;
using Ansari_Website.Application.CPanel.Survey.Queries.GetById;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class SurveyController : BaseController
{
    private readonly IMapper _mapper;

    public SurveyController(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var Surveys = await Mediator.Send(new GetAllSurveysQuery());
        return View(Surveys);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        if (id > 0)
        {
            //isSeenTrue
            var Survey = await Mediator.Send(new GetSurveyByIdQuery
            {
                Id = id,
            });
            if (Survey != null)
            {
                var IsSeen = await Mediator.Send(new ViewSurveyCommand
                {
                    Id = id,
                });
                var result = _mapper.Map<SurveyVM>(Survey);
                return View(result);
            }
        }

        return View(new SurveyVM());
    }
}
