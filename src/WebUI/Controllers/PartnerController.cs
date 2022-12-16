using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.Partner.Commands.Create;
using Ansari_Website.Application.CPanel.Partner.Commands.Delete;
using Ansari_Website.Application.CPanel.Partner.Queries.GetAll;
using Ansari_Website.Application.CPanel.Partner.Queries.GetById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class PartnerController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IFileHandler _fileHandler;

    public PartnerController(IMapper mapper, IFileHandler fileHandler)
    {
        _mapper = mapper;
        _fileHandler = fileHandler;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> CreateAsync()
    {
        var command = new CreateUpdatePartnerCommand();
        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdatePartnerCommand command)
    {
        if (ModelState.IsValid)
        {
            var PartnerImagePath = (command.PartnerImage != null) ? /*command.PartnerCode +*/ command.PartnerImage.FileName.Substring(command.PartnerImage.FileName.LastIndexOf('.')) : null;
            if (PartnerImagePath != null)
                command.ImageUrl = PartnerImagePath;

            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                if (PartnerImagePath != null)
                    _fileHandler.UploadFile("Partners", command.PartnerImage, "" /*command.PartnerCode.ToString()*/);
                RedirectToAction("Index");
            }
        }
        return View(command);
    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        var command = new CreateUpdatePartnerCommand();

        if (id > 0)
        {
            var Partner = await Mediator.Send(new GetPartnerByIdQuery
            {
                Id = id,
            });
            if (Partner != null)
            {
                command = _mapper.Map<CreateUpdatePartnerCommand>(Partner);
            }
        }
        return View("Create", command);
    }

    [HttpPost]
    public async Task<JsonResult> DeleteAsync(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeletePartnerCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    public async Task<JsonResult> GetAll()
    {
        var Partners = await Mediator.Send(new GetAllPartnersQuery());
        return Json(Partners);
    }
}
