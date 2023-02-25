using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.Common.Models;
using Ansari_Website.Application.CPanel.Offer.Commands.Create;
using Ansari_Website.Application.CPanel.Offer.Queries.GetAll;
using Ansari_Website.Application.CPanel.Offer.Queries.GetById;
using Ansari_Website.Domain.Entities.CPanel;
using Ansari_Website.Domain.Enums;
using Ansari_Website.Infrastructure.Common;
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
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;

        var Offers = await Mediator.Send(new GetAllOffersQuery());
        return View(Offers);
        //return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;

        var offerVM = new OfferVM();
        if (id > 0)
        {
            var Offer = await Mediator.Send(new GetOfferByIdQuery
            {
                Id = id,
            });
            if (Offer != null)
            {
                ViewBag.Offers = await Mediator.Send(new GetAllOffersQuery());
                offerVM = _mapper.Map<OfferVM>(Offer);
                offerVM.Title = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? offerVM.TitleEn : offerVM.TitleAr;
                offerVM.Description = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? offerVM.DescriptionEn : offerVM.DescriptionAr;
            }
        }
        return View(offerVM);
    }


}
