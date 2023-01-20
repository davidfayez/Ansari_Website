using Ansari_Website.Application.CPanel.Complaint.Queries.GetAll;
using Ansari_Website.Application.CPanel.Complaint.Queries.GetById;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class ComplaintController : BaseController
{
    private readonly IMapper _mapper;

    public ComplaintController(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<IActionResult> IndexAsync()
    {
        var Complaints = await Mediator.Send(new GetAllComplaintsQuery());

        return View(Complaints);
    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        if (id > 0)
        {
            var Complaint = await Mediator.Send(new GetComplaintByIdQuery
            {
                Id = id,
            });
            if (Complaint != null)
            {
                var result = _mapper.Map<ComplaintVM>(Complaint);
                return View(result);
            }
        }

        return View(new ComplaintVM());
    }
}
