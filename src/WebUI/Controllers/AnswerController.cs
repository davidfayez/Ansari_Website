using Ansari_Website.Application.CPanel.Answer.Commands.Create;
using Ansari_Website.Application.CPanel.Answer.Commands.Delete;
using Ansari_Website.Application.CPanel.Answer.Queries.GetAll;
using Ansari_Website.Application.CPanel.Answer.Queries.GetById;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class AnswerController : BaseController
{
    private readonly IMapper _mapper;

    public AnswerController(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        var Answers = await Mediator.Send(new GetAllAnswersQuery());

        return View(Answers);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateUpdateAnswerCommand());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateAnswerCommand command)
    {
        if (ModelState.IsValid)
        {
            var isSuccess = await Mediator.Send(command);
            if(isSuccess)
            {
                var Answers = await Mediator.Send(new GetAllAnswersQuery());
                return PartialView("_AnswersList", Answers);
            }
        }
        return PartialView("_PopUp", command);

    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        if (id > 0)
        {
            var Answer = await Mediator.Send(new GetAnswerByIdQuery
            {
                Id = id,
            });
            if (Answer != null)
            {
                var result = _mapper.Map<CreateUpdateAnswerCommand>(Answer);
                return PartialView("_PopUp", result);
            }
        }

        return PartialView("_PopUp", new CreateUpdateAnswerCommand());
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeleteAnswerCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
        //var Answers = await Mediator.Send(new GetAllAnswersQuery());
        //return PartialView("_AnswersList", Answers);
    }

    public async Task<JsonResult> GetAll()
    {
        var Answers = await Mediator.Send(new GetAllAnswersQuery());
        return Json(Answers);
    }
}
