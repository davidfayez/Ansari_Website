using Ansari_Website.Application.CPanel.Blog.Queries.GetAll;
using Ansari_Website.Application.CPanel.Blog.Queries.GetById;
using Ansari_Website.Application.CPanel.Blog.VM;
using Ansari_Website.Application.CPanel.OverView.Queries.GetAll;
using Ansari_Website.Domain.Enums;
using Ansari_Website.Infrastructure.Common;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
public class OverViewController : BaseController
{
    private readonly IMapper _mapper;

    public OverViewController(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        var OverViews = await Mediator.Send(new GetAllOverViewsQuery
        {
            LangId = Request.GetLangIdFromHeader()
        }); ;
        return View(OverViews);
    }

}
