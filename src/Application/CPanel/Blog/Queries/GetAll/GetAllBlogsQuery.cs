using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Blog.VM;
using Ansari_Website.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ansari_Website.Application.CPanel.Blog.Queries.GetAll;
public class GetAllBlogsQuery : IRequest<List<BlogVM>>
{
    public int LangId { get; set; }
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

        //var BlogVMs = _mapper.Map<List<BlogVM>>(Blogs.ToList());
        var BlogVMs = Blogs.Select(s => new BlogVM
        {
            Id = s.Id,
            AltImage= s.AltImage,
            ImageUrl= s.ImageUrl,
            DescriptionAr = s.DescriptionAr,
            DescriptionEn = s.DescriptionEn,
            DoctorId= s.DoctorId,
            Order = s.Order,
            TitleAr = s.TitleAr,
            TitleEn= s.TitleEn,
            DepartmentId= s.DepartmentId,
            DoctorName = s.Doctor.FullName,
            DepartmentName = (request.LangId == (int)ELanguages.AR) ? s.Department.TitleAr : s.Department.TitleEn,
            Title = (request.LangId == (int)ELanguages.AR) ? s.TitleAr : s.TitleEn,
            Description = (request.LangId == (int)ELanguages.AR) ? s.DescriptionAr : s.DescriptionEn,
        }).ToList();
        return Task.FromResult(BlogVMs);
    }
}

