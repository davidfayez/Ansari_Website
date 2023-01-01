using Ansari_Website.Application.Common.Resources;
using Ansari_Website.Application.CPanel.Answer.Queries.GetAll;
using Ansari_Website.Application.CPanel.Question.Commands.Create;
using Ansari_Website.Application.CPanel.Question.Commands.Delete;
using Ansari_Website.Application.CPanel.Question.Queries.GetAll;
using Ansari_Website.Application.CPanel.Question.Queries.GetById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ansari_Website.WebUI.Controllers;
public class QuestionController : BaseController
{
    private readonly IMapper _mapper;

    public QuestionController(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var Questions = await Mediator.Send(new GetAllQuestionsQuery());
        return View(Questions);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var command = new CreateUpdateQuestionCommand();
        await FillDDLAsync(command);
        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateQuestionCommand command)
    {
        if (ModelState.IsValid)
        {
            var isSuccess = await Mediator.Send(command);
            return isSuccess ? RedirectToAction("Index") : View(command);
        }
        await FillDDLAsync(command);
        return View(command);
    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        if (id > 0)
        {
            var Question = await Mediator.Send(new GetQuestionByIdQuery
            {
                Id = id,
            });
            if (Question != null)
            {
                var result = _mapper.Map<CreateUpdateQuestionCommand>(Question);
                await FillDDLAsync(result);
                return View("Create", result);
            }
        }

        return View("Create", new CreateUpdateQuestionCommand());
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeleteQuestionCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    public async Task<JsonResult> GetAll()
    {
        var Questions = await Mediator.Send(new GetAllQuestionsQuery());
        return Json(Questions);
    }

    private async Task FillDDLAsync(CreateUpdateQuestionCommand command)
    {
        var Answers = await Mediator.Send(new GetAllAnswersQuery());
        command.Answers.AddRange(Answers.Select(a => new SelectListItem { Text = a.NameEn, Value = a.Id.ToString() }));
        
    }
}
