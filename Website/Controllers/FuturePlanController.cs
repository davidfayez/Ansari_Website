using Ansari_Website.Application.CPanel.FuturePlan.Queries.GetAll;
using Ansari_Website.Application.CPanel.FuturePlan.Queries.GetById;
using Ansari_Website.Domain.Enums;
using Ansari_Website.Infrastructure.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
public class FuturePlanController : BaseController
{
    private readonly IMapper _mapper;

    public FuturePlanController(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexAsync()
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        var FuturePlans = await Mediator.Send(new GetAllFuturePlansQuery { LangId = Request.GetLangIdFromHeader() });
        return View(FuturePlans);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;

        if (id > 0)
        {
            ViewBag.FuturePlans = await Mediator.Send(new GetAllFuturePlansQuery { LangId = Request.GetLangIdFromHeader() });

            var FuturePlan = await Mediator.Send(new GetFuturePlanByIdQuery
            {
                Id = id,
            });
            if (FuturePlan != null)
            {
                var result = _mapper.Map<FuturePlanVM>(FuturePlan);
                result.Title = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? result.TitleEn : result.TitleAr;
                result.Description = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? result.DescriptionEn : result.DescriptionAr;
                return View(result);
            }
        }
        return View(new FuturePlanVM());
    }
}
