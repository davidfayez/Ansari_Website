using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.Offer.Commands.Create;
using Ansari_Website.Application.CPanel.Offer.Queries.GetAll;
using Ansari_Website.Application.CPanel.Offer.Queries.GetById;
using Ansari_Website.Domain.Entities.CPanel;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
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
        //return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        //var offerVM = new OfferVM();
        //if (id > 0)
        //{
        //    var Offer = await Mediator.Send(new GetOfferByIdQuery
        //    {
        //        Id = id,
        //    });
        //    if (Offer != null)
        //    {
        //        offerVM = _mapper.Map<OfferVM>(Offer);
        //    }
        //}
        //return View(offerVM);
        return View();
    }


}
