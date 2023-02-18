using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.Common.Models;
using Ansari_Website.Application.Common.Resources;
using Ansari_Website.Application.CPanel.Blog.Commands.Create;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;
using Ansari_Website.Application.User.Commands.Create;
using Ansari_Website.Application.User.Commands.Delete;
using Ansari_Website.Application.User.Queries.GetAll;
using Ansari_Website.Application.User.Queries.GetById;
using Ansari_Website.Domain.Enums;
using AutoMapper;
using ERP.DAL.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

    public async Task<IActionResult> Doctors()
    {
        var Doctors = await Mediator.Send(new GetAllUsersQuery { Type=(int)UserType.Doctor});
        return View(Doctors);
    }

    [HttpGet]
    public async Task<IActionResult> CreateAsync()
    {
        var command = new CreateUpdateUserCommand() { IsNew = true };
        await FillDDLAsync(command);
        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateUserCommand command)
    {
        if (ModelState.IsValid)
        {
            //var UserImagePath = (command.UserImage != null) ? command.Id + command.UserImage.FileName.Substring(command.UserImage.FileName.LastIndexOf('.')) : null;
            var UserImagePath = (command.UserImage != null) ? command.UserImage.FileName : null;

            if (UserImagePath != null)
                command.Image = UserImagePath;

            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                if (UserImagePath != null)
                {
                    var mainFolderPath = "E:\\Private\\Ansari_Website\\Website\\wwwroot\\images";
                    _fileHandler.UploadFile("Users", command.UserImage);
                    _fileHandler.UploadFile("Users", command.UserImage, mainFolderPath);
                }
                return RedirectToAction("Index");
            }
        }
        await FillDDLAsync(command);
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
                await FillDDLAsync(result);
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

    private async Task FillDDLAsync(CreateUpdateUserCommand command)
    {
        command.Departments.Add(new SelectListItem { Text = Global.SelectOne, Value = "" });
        var Departments = await Mediator.Send(new GetAllDepartmentsQuery());
        command.Departments.AddRange(Departments.Select(a => new SelectListItem { Text = a.TitleEn, Value = a.Id.ToString() }));

    }

}
