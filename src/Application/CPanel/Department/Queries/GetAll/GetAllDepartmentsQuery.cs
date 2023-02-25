using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Department.Queries.GetAll;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.CPanel.Department.Queries.GetAll;
public class GetAllDepartmentsQuery : IRequest<List<DepartmentVM>>
{
    public Speciality? Speciality { get; set; }
    public int LangId { get; set; }
}

public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<DepartmentVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllDepartmentsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<DepartmentVM>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var Departments = _applicationDbContext.Departments.Where(s => !s.IsDeleted);

        if (request.Speciality != null)
            Departments = Departments.Where(s => s.Speciality == request.Speciality);

        //var DepartmentVMs = _mapper.Map<List<DepartmentVM>>(Departments.ToList());
        var DepartmentVMs = Departments.Select(s => new DepartmentVM
        {
            Id= s.Id,
            DescriptionAr =s.DescriptionAr,
            DescriptionEn=s.DescriptionEn,
            TitleAr= s.TitleAr,
            TitleEn= s.TitleEn,
            Title = (request.LangId == (int)ELanguages.AR) ? s.TitleAr : s.TitleEn,
            Description = (request.LangId == (int)ELanguages.AR) ? s.DescriptionAr : s.DescriptionEn,
        }).ToList();
        return Task.FromResult(DepartmentVMs);
    }
}

