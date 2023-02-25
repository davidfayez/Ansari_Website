using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.Common.Models;
using Ansari_Website.Application.CPanel.Partner.Commands.Create;
using Ansari_Website.Application.CPanel.Partner.Queries.GetAll;
using Ansari_Website.Application.CPanel.Partner.Queries.GetById;
using Ansari_Website.Domain.Enums;
using Ansari_Website.Infrastructure.Common;
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
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        var Partner = await Mediator.Send(new GetAllPartnersQuery());
        return View(Partner);
        //return View();
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        var partnerVM = new PartnerVM();
        if (id > 0)
        {
            var Partner = await Mediator.Send(new GetPartnerByIdQuery
            {
                Id = id,
            });
            if (Partner != null)
            {
                partnerVM = _mapper.Map<PartnerVM>(Partner);
                partnerVM.Title = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? partnerVM.TitleEn : partnerVM.TitleAr;
                partnerVM.Description = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? partnerVM.DescriptionEn : partnerVM.DescriptionAr;
            }
        }
        ViewBag.Partners = await Mediator.Send(new GetAllPartnersQuery());
        return View(partnerVM);
        //return View();
    }
}
