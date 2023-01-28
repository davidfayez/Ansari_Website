using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.User.Commands.Create;
using Ansari_Website.Application.User.Queries.GetById;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
public class AccountController : BaseController
{
    private readonly IFileHandler _fileHandler;
    private readonly IMapper _mapper;

    public AccountController(IFileHandler fileHandler, IMapper mapper)
    {
        _fileHandler = fileHandler;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(new CreateUpdateUserCommand() { IsNew = true });
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUpdateUserCommand command)
    {
        if (ModelState.IsValid)
        {
            var UserImagePath = (command.UserImage != null) ? command.Id + command.UserImage.FileName.Substring(command.UserImage.FileName.LastIndexOf('.')) : null;
            if (UserImagePath != null)
                command.Image = UserImagePath;

            var isSuccess = await Mediator.Send(command);

            if (isSuccess)
                return RedirectToAction("Index");

        }
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> Profile(string id)
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
                return View(result);
            }
        }

        return View(new CreateUpdateUserCommand());
    }
}
