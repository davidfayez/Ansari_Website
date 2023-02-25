using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.Common.Models;
using Ansari_Website.Application.CPanel.Testiminie.Commands.Create;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetAll;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetById;
using Ansari_Website.Application.CPanel.Testiminie.VM;
using Ansari_Website.Domain.Enums;
using Ansari_Website.Infrastructure.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
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

        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;
        var Testiminies = await Mediator.Send(new GetAllTestiminiesQuery());
        return View(Testiminies);
    }


    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;

        var testiminieVM = new TestiminieVM();

        if (id > 0)
        {
            var Testiminie = await Mediator.Send(new GetTestiminieByIdQuery
            {
                Id = id,
            });
            if (Testiminie != null)
            {
                testiminieVM = _mapper.Map<TestiminieVM>(Testiminie);
                testiminieVM.Title = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? testiminieVM.TitleEn : testiminieVM.TitleAr;
                testiminieVM.Description = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? testiminieVM.DescriptionEn : testiminieVM.DescriptionAr;
            }
        }
        return View(testiminieVM);
    }
}
