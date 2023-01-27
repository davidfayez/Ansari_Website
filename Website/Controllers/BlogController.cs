using Ansari_Website.Application.CPanel.Blog.Commands.Create;
using Ansari_Website.Application.CPanel.Blog.Queries.GetAll;
using Ansari_Website.Application.CPanel.Blog.Queries.GetById;
using Ansari_Website.Application.CPanel.Blog.VM;
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
        var Blogs = await Mediator.Send(new GetAllBlogsQuery());
        return View(Blogs);
    }

    public async Task<IActionResult> Details(int id)
    {
        if (id > 0)
        {
            var Blog = await Mediator.Send(new GetBlogByIdQuery
            {
                Id = id,
            });
            if (Blog != null)
            {
                var result = _mapper.Map<BlogVM>(Blog);
                return View(result);
            }
        }
        return View(new BlogVM());
    }

}
