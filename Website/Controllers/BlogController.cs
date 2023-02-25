using Ansari_Website.Application.CPanel.Blog.Commands.Create;
using Ansari_Website.Application.CPanel.Blog.Queries.GetAll;
using Ansari_Website.Application.CPanel.Blog.Queries.GetById;
using Ansari_Website.Application.CPanel.Blog.VM;
using Ansari_Website.Domain.Enums;
using Ansari_Website.Infrastructure.Common;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
public class BlogController : BaseController
{
    private readonly IMapper _mapper;

    public BlogController(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<IActionResult> Index()
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;

        var Blogs = await Mediator.Send(new GetAllBlogsQuery());
        return View(Blogs);
    }

    public async Task<IActionResult> Details(int id)
    {
        ViewBag.IsArabic = Request.GetLangIdFromHeader() == (int)ELanguages.AR;

        if (id > 0)
        {
            var Blog = await Mediator.Send(new GetBlogByIdQuery
            {
                Id = id,
            });
            if (Blog != null)
            {
                var result = _mapper.Map<BlogVM>(Blog);
                result.Title = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? result.TitleEn : result.TitleAr;
                result.Description = (Request.GetLangIdFromHeader() == (int)ELanguages.EN) ? result.DescriptionEn : result.DescriptionAr;
                ViewBag.Blogs = await Mediator.Send(new GetAllBlogsQuery());
                return View(result);
            }
        }
        return View(new BlogVM());
    }

}
