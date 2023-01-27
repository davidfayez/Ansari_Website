using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.Testiminie.Commands.Create;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetAll;
using Ansari_Website.Application.CPanel.Testiminie.Queries.GetById;
using Ansari_Website.Application.CPanel.Testiminie.VM;
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
        //var Testiminies = await Mediator.Send(new GetAllTestiminiesQuery());
        //return View(Testiminies);
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        //var testiminieVM = new TestiminieVM();

        //if (id > 0)
        //{
        //    var Testiminie = await Mediator.Send(new GetTestiminieByIdQuery
        //    {
        //        Id = id,
        //    });
        //    if (Testiminie != null)
        //    {
        //        testiminieVM = _mapper.Map<TestiminieVM>(Testiminie);
        //    }
        //}
        //return View(testiminieVM);
        return View();
    }
}
