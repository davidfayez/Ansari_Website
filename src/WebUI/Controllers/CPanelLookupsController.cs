using Ansari_Website.Application.CPanel.AboutUs.Commands.Create;
using Ansari_Website.Application.CPanel.AboutUs.Queries.GetById;
using Ansari_Website.Application.CPanel.SiteInfo.Commands.Create;
using Ansari_Website.Application.CPanel.SiteInfo.Queries.GetById;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class CPanelLookupsController : BaseController
{
    private readonly IMapper _mapper;

    public CPanelLookupsController(IMapper mapper)
    {
        _mapper = mapper;
    }

    #region Site Info
    [HttpGet]
    public async Task<IActionResult> SiteInfoAsync()
    {
        var SiteInfo = await Mediator.Send(new GetSiteInfoQuery());
        var command = _mapper.Map<CreateUpdateSiteInfoCommand>(SiteInfo);
        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> SiteInfoAsync(CreateUpdateSiteInfoCommand command)
    {
        var isSuccesfully = await Mediator.Send(command);
        ViewBag.isSuccesfully = isSuccesfully;
        return View(command);
    }

    #endregion

    #region AboutUs
    [HttpGet]
    public async Task<IActionResult> AboutUsAsync()
    {
        var AboutUs = await Mediator.Send(new GetAboutUsQuery());
        var command = _mapper.Map<CreateUpdateAboutUsCommand>(AboutUs);
        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> AboutUsAsync(CreateUpdateAboutUsCommand command)
    {
        var isSuccesfully = await Mediator.Send(command);
        ViewBag.isSuccesfully = isSuccesfully;
        return View(command);
    }

    #endregion

    #region Setting

    [HttpGet]
    public IActionResult Setting()
    {
        return View();
    }
    #endregion
}
