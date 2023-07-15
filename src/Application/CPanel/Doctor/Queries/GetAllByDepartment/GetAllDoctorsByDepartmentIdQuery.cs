using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.User.Queries.GetAll;
using Ansari_Website.Application.User.VM;

namespace Ansari_Website.Application.CPanel.Doctor.Queries.GetAllByDepartment;
public class GetAllDoctorsByDepartmentIdQuery : IRequest<List<UserVM>>
{
    public int? DepartmentId { get; set; }
}

public class GetAllDoctorsByDepartmentIdQueryHandler : IRequestHandler<GetAllDoctorsByDepartmentIdQuery, List<UserVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllDoctorsByDepartmentIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<UserVM>> Handle(GetAllDoctorsByDepartmentIdQuery request, CancellationToken cancellationToken)
    {
        var Users = _applicationDbContext.AspNetUsers.Include(s => s.Department).Where(s => !s.IsDeleted);

        if (request.DepartmentId.HasValue)
            Users = Users.Where(s => s.DepartmentId == request.DepartmentId.Value);

        var UserVMs = _mapper.Map<List<UserVM>>(Users.ToList());
        return Task.FromResult(UserVMs);
    }
}

