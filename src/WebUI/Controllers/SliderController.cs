using Ansari_Website.Application.CPanel.Slider.Commands.Create;
using Ansari_Website.Application.CPanel.Slider.Commands.Delete;
using Ansari_Website.Application.CPanel.Slider.Queries.GetAll;
using Ansari_Website.Application.CPanel.Slider.Queries.GetById;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class SliderController : BaseController
{
    private readonly IMapper _mapper;

    public SliderController(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var Sliders = await Mediator.Send(new GetAllSlidersQuery());

        return View(Sliders);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateUpdateSliderCommand());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateSliderCommand command)
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
            var Slider = await Mediator.Send(new GetSliderByIdQuery
            {
                Id = id,
            });
            if (Slider != null)
            {
                var result = _mapper.Map<CreateUpdateSliderCommand>(Slider);
                return View("Create", result);
            }
        }

        return View("Create", new CreateUpdateSliderCommand());
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeleteSliderCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    public async Task<JsonResult> GetAll()
    {
        var Sliders = await Mediator.Send(new GetAllSlidersQuery());
        return Json(Sliders);
    }
}
