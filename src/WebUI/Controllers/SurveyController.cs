using Ansari_Website.Application.CPanel.Complaint.Queries.GetAll;
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
    public IActionResult Index()
    {
        //var Complaints = await Mediator.Send(new GetAllComplaintsQuery());
        //return View(Complaints);
        return View();
    }
}
