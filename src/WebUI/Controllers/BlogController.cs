using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.Common.Resources;
using Ansari_Website.Application.CPanel.Blog.Commands.Create;
using Ansari_Website.Application.CPanel.Blog.Commands.Delete;
using Ansari_Website.Application.CPanel.Blog.Queries.GetAll;
using Ansari_Website.Application.CPanel.Blog.Queries.GetById;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;
using Ansari_Website.Application.User.Queries.GetAll;
using Ansari_Website.Domain.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ansari_Website.WebUI.Controllers;
public class BlogController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IFileHandler _fileHandler;

    public BlogController(IMapper mapper, IFileHandler fileHandler)
    {
        _mapper = mapper;
        _fileHandler = fileHandler;
    }
    public async Task<IActionResult> Index()
    {
        var Blogs = await Mediator.Send(new GetAllBlogsQuery());
        return View(Blogs);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var command = new CreateUpdateBlogCommand();
        await FillBlogDDLAsync(command);
        return View(command);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUpdateBlogCommand command)
    {
        if (ModelState.IsValid)
        {
            var BlogImagePath = (command.BlogImage != null) ? command.BlogImage.FileName : null;

            if (BlogImagePath != null)
                command.ImageUrl = BlogImagePath;

            var isSuccess = await Mediator.Send(command);
            if (isSuccess)
            {
                if (BlogImagePath != null)
                {
                    var mainFolderPath = "E:\\Private\\Ansari_Website\\Website\\wwwroot\\images";
                    _fileHandler.UploadFile("Blogs", command.BlogImage);
                    _fileHandler.UploadFile("Blogs", command.BlogImage, mainFolderPath);
                }

                //var Blogs = await Mediator.Send(new GetAllBlogsQuery());
                ViewBag.IsSuccess = isSuccess;
                return RedirectToAction("Index");
            }
        }
        return View(command);

    }

    [HttpGet]
    public async Task<IActionResult> EditAsync(int id)
    {
        if (id > 0)
        {
            var Blog = await Mediator.Send(new GetBlogByIdQuery
            {
                Id = id,
            });
            if (Blog != null)
            {
                var result = _mapper.Map<CreateUpdateBlogCommand>(Blog);
                return View(result);
            }
        }

        return View(new CreateUpdateBlogCommand());
    }

    [HttpPost]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        if (id > 0)
        {
            var isSuccess = await Mediator.Send(
              new DeleteBlogCommand
              {
                  Id = id
              });
            return Json(isSuccess);
        }
        return Json(false);
    }

    public async Task<JsonResult> GetAll()
    {
        var Blogs = await Mediator.Send(new GetAllBlogsQuery());
        return Json(Blogs);
    }

    private async Task FillBlogDDLAsync(CreateUpdateBlogCommand command)
    {
        command.Doctors.Add(new SelectListItem { Text = Global.SelectOne, Value = "" });
        var Doctors = await Mediator.Send(new GetAllUsersQuery() { Type= (int)UserType.Doctor} );
        command.Doctors.AddRange(Doctors.Select(a => new SelectListItem { Text = a.FullName, Value = a.Id.ToString() }));

        command.Departments.Add(new SelectListItem { Text = Global.SelectOne, Value = "" });
        var Departments = await Mediator.Send(new GetAllDepartmentsQuery());
        command.Departments.AddRange(Departments.Select(a => new SelectListItem { Text = a.TitleEn, Value = a.Id.ToString() }));

    }

}
