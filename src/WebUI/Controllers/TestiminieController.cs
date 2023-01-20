using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.Doctor.Commands.Create;
using Ansari_Website.Application.CPanel.Testiminie.Commands.Create;
using Ansari_Website.Application.CPanel.Testiminie.Commands.CreateDetail;
using Ansari_Website.Application.CPanel.Testiminie.Commands.Delete;
using Ansari_Website.Application.CPanel.Testiminie.Commands.DeleteDetail;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetAll;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetAllDetails;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetById;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetDetailsById;
using Ansari_Website.Application.CPanel.Testiminie.VM;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class TestiminieController : BaseController
{
    private readonly IFileHandler _fileHandler;
    private readonly IMapper _mapper;

    public TestiminieController(IFileHandler fileHandler, IMapper mapper)
    {
        _fileHandler = fileHandler;
        _mapper = mapper;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var Testiminies = await Mediator.Send(new GetAllTestiminiesQuery());

        return View(Testiminies);
    }

    public IActionResult Create()
    {
        return View(new CreateUpdateTestiminieCommand() { ImageUrl= "rheumatism.jpg" });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateTestiminieCommand command)
    {
        if (ModelState.IsValid)
        {
            var TestiminieImagePath = (command.TestiminieImage != null) ? command.TitleEn.ToString() + command.TestiminieImage.FileName.Substring(command.TestiminieImage.FileName.LastIndexOf('.')) : null;
            if (TestiminieImagePath != null)
                command.ImageUrl = TestiminieImagePath;

            foreach (var detail in command.TestiminieDetailVMs)
            {
                var TestiminieDetailImagePath = (detail.TestiminieDetailImage != null) ? detail.TitleEn.ToString() + detail.TestiminieDetailImage.FileName.Substring(detail.TestiminieDetailImage.FileName.LastIndexOf('.')) : null;
                if (TestiminieDetailImagePath != null)
                    detail.ImageUrl = TestiminieDetailImagePath;
            }

            var res = await Mediator.Send(command);

            if (res > 0)
            {
                if (TestiminieImagePath != null)
                    _fileHandler.UploadFile("Testiminies", command.TestiminieImage, command.TitleEn.ToString());

                foreach (var detail in command.TestiminieDetailVMs)
                {
                    var TestiminieDetailImagePath = (detail.TestiminieDetailImage != null) ? detail.TitleEn.ToString() + detail.TestiminieDetailImage.FileName.Substring(detail.TestiminieDetailImage.FileName.LastIndexOf('.')) : null;
                    if (TestiminieDetailImagePath != null)
                        _fileHandler.UploadFile("Testiminies", detail.TestiminieDetailImage, detail.TitleEn.ToString());
                }

                return RedirectToAction("Index");
            }
        }
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        var command = new CreateUpdateTestiminieCommand();

        if (id > 0)
        {
            var Testiminie = await Mediator.Send(new GetTestiminieByIdQuery
            {
                Id = id,
            });
            if (Testiminie != null)
            {
                command = _mapper.Map<CreateUpdateTestiminieCommand>(Testiminie);
            }
        }
        return View("Create", command);
    }


    [HttpPost]
    public async Task<JsonResult> DeleteDetail(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeleteTestiminieDetailsByIdCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeleteTestiminieCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    [HttpGet]
    public async Task<IActionResult> GetTestiminieDetailById(int id)
    {
        var command = new CreateUpdateTestiminieDetailCommand();

        if (id > 0)
        {
            var Testiminie = await Mediator.Send(new GetTestiminieDetailByIdQuery
            {
                Id = id,
            });
            if (Testiminie != null)
            {
                command = _mapper.Map<CreateUpdateTestiminieDetailCommand>(Testiminie);
            }
        }
        return PartialView("_EditPopupDetail", command);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTestiminieDetailByTestiminieId(int id)
    {
        var TestiminieDetailVMs = new List<TestiminieDetailVM>();
        if (id > 0)
        {
            var TestiminieDetails = await Mediator.Send(new GetAllDetailsByTestiminieIdQuery
            {
                Id = id,
            });
            TestiminieDetailVMs = _mapper.Map<List<TestiminieDetailVM>>(TestiminieDetails);
        }
        return PartialView("_TestiminieDetailsList", TestiminieDetailVMs);
    }

    [HttpGet]
    public async Task<IActionResult> NewTestiminieDetail(int id)
    {

        return PartialView("_PopupDetail", new CreateUpdateTestiminieDetailCommand());
    }

    [HttpPost]
    public async Task<IActionResult> EditTestiminieDetail(CreateUpdateTestiminieDetailCommand command)
    {
        if (ModelState.IsValid)
        {
            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                ViewBag.IsSuccess = isSuccess;
                ViewBag.TestiminieId = command.TestiminieId;
                ViewBag.Id = command.TestiminieId;
                return PartialView("_EditPopupDetail", new CreateUpdateTestiminieDetailCommand());
            }
        }
        return PartialView("_EditPopupDetail", command);

    }
}
