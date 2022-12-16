using Ansari_Website.Application.CPanel.SurveyQuestion.Commands.Create;
using Ansari_Website.Application.CPanel.SurveyQuestion.Commands.Delete;
using Ansari_Website.Application.CPanel.SurveyQuestion.Queries.GetAll;
using Ansari_Website.Application.CPanel.SurveyQuestion.Queries.GetById;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class SurveyQuestionController : BaseController
{
    private readonly IMapper _mapper;

    public SurveyQuestionController(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var SurveyQuestions = await Mediator.Send(new GetAllSurveyQuestionsQuery());

        return View(SurveyQuestions);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateUpdateSurveyQuestionCommand());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateSurveyQuestionCommand command)
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
            var SurveyQuestion = await Mediator.Send(new GetSurveyQuestionByIdQuery
            {
                Id = id,
            });
            if (SurveyQuestion != null)
            {
                var result = _mapper.Map<CreateUpdateSurveyQuestionCommand>(SurveyQuestion);
                return View("Create", result);
            }
        }

        return View("Create", new CreateUpdateSurveyQuestionCommand());
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeleteSurveyQuestionCommand
              {
                  Id = id
              });
            //return Json(isSuccess);
        }
        var SurveyQuestions = await Mediator.Send(new GetAllSurveyQuestionsQuery());
        return PartialView("_SurveyQuestionsList", SurveyQuestions);
    }

    public async Task<JsonResult> GetAll()
    {
        var SurveyQuestions = await Mediator.Send(new GetAllSurveyQuestionsQuery());
        return Json(SurveyQuestions);
    }
}
