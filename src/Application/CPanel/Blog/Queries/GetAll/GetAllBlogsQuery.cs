using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Blog.VM;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ansari_Website.Application.CPanel.Blog.Queries.GetAll;
public class GetAllBlogsQuery : IRequest<List<BlogVM>>
{
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public int? DoctorId { get; set; }
    public int? DepartmentId { get; set; }
    public List<SelectListItem> Doctors { get; set; }
    public List<SelectListItem> Departments { get; set; }

}
public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, List<BlogVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllBlogsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<BlogVM>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
    {
        var Blogs = _applicationDbContext.Blogs.Include(s=>s.Department)
                                               .Include(s=>s.Doctor)
                                               .Where(s => !s.IsDeleted);

        var BlogVMs = _mapper.Map<List<BlogVM>>(Blogs.ToList());
        return Task.FromResult(BlogVMs);
    }
}

