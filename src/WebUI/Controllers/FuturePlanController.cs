using Ansari_Website.Application.CPanel.FuturePlan.Commands.Create;
using Ansari_Website.Application.CPanel.FuturePlan.Commands.Delete;
using Ansari_Website.Application.CPanel.FuturePlan.Queries.GetAll;
using Ansari_Website.Application.CPanel.FuturePlan.Queries.GetById;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class FuturePlanController : BaseController
{
    private readonly IMapper _mapper;

    public FuturePlanController(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var FuturePlans = await Mediator.Send(new GetAllFuturePlansQuery());

        return View(FuturePlans);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateUpdateFuturePlanCommand());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateFuturePlanCommand command)
    {
        if (ModelState.IsValid)
        {
            var isSuccess = await Mediator.Send(command);
            return isSuccess ? RedirectToAction("Index") : View(command);
        }
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        if (id > 0)
        {
            var FuturePlan = await Mediator.Send(new GetFuturePlanByIdQuery
            {
                Id = id,
            });
            if (FuturePlan != null)
            {
                var result = _mapper.Map<CreateUpdateFuturePlanCommand>(FuturePlan);
                return View("Create", result);
            }
        }

        return View("Create", new CreateUpdateFuturePlanCommand());
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeleteFuturePlanCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    public async Task<JsonResult> GetAll()
    {
        var FuturePlans = await Mediator.Send(new GetAllFuturePlansQuery());
        return Json(FuturePlans);
    }
}
