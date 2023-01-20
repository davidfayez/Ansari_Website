using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.User.Commands.Create;
using Ansari_Website.Application.User.Commands.Delete;
using Ansari_Website.Application.User.Queries.GetAll;
using Ansari_Website.Application.User.Queries.GetById;
using AutoMapper;
using ERP.DAL.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ansari_Website.WebUI.Controllers;
public class UserController : BaseController
{
    private readonly IMapper _mapper;
    private readonly UserManager<AspNetUser> _userManager;
    private readonly IFileHandler _fileHandler;

    public UserController(IMapper mapper, UserManager<AspNetUser> userManager,IFileHandler fileHandler)
    {
        _mapper = mapper;
        _userManager = userManager;
        _fileHandler = fileHandler;
    }
    public async Task<IActionResult> IndexAsync()
    {
        var Users = await Mediator.Send(new GetAllUsersQuery());

        return View(Users);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new CreateUpdateUserCommand() { IsNew=true});
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateUserCommand command)
    {
        if (ModelState.IsValid)
        {
            var UserImagePath = (command.UserImage != null) ? command.Id + command.UserImage.FileName.Substring(command.UserImage.FileName.LastIndexOf('.')) : null;
            if (UserImagePath != null)
                command.Image = UserImagePath;

            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                if (UserImagePath != null)
                    _fileHandler.UploadFile("Users", command.UserImage,command.Id.ToString());
                return RedirectToAction("Index");
            }
        }
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var User = await Mediator.Send(new GetUserByIdQuery
            {
                Id = id,
            });
            if (User != null)
            {
                var result = _mapper.Map<CreateUpdateUserCommand>(User);
                result.IsNew = false;
                return View("Create", result);
            }
        }

        return View("Create", new CreateUpdateUserCommand());
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var isSuccess = await Mediator.Send(
              new DeleteUserCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    public async Task<JsonResult> GetAll()
    {
        var Users = await Mediator.Send(new GetAllUsersQuery());
        return Json(Users);
    }
}
