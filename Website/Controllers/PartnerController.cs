using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.Partner.Commands.Create;
using Ansari_Website.Application.CPanel.Partner.Queries.GetAll;
using Ansari_Website.Application.CPanel.Partner.Queries.GetById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
public class PartnerController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IFileHandler _fileHandler;

    public PartnerController(IMapper mapper, IFileHandler fileHandler)
    {
        _mapper = mapper;
        _fileHandler = fileHandler;
    }

    public async Task<IActionResult> IndexAsync()
    {
        //var Partner = await Mediator.Send(new GetAllPartnersQuery());
        //return View(Partner);
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        //var partnerVM = new PartnerVM();
        //if (id > 0)
        //{
        //    var Partner = await Mediator.Send(new GetPartnerByIdQuery
        //    {
        //        Id = id,
        //    });
        //    if (Partner != null)
        //    {
        //        partnerVM = _mapper.Map<PartnerVM>(Partner);
        //    }
        //}
        //return View(partnerVM);
        return View();
    }
}
