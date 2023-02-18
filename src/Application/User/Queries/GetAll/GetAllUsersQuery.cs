using Ansari_Website.Application.User.VM;

namespace Ansari_Website.Application.User.Queries.GetAll;
public class GetAllUsersQuery : IRequest<List<UserVM>>
{
    public int? Type { get; set; }
}

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<UserVM>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var Users = _applicationDbContext.AspNetUsers.Include(s=>s.Department).Where(s => !s.IsDeleted);
        
        if(request.Type.HasValue)
            Users = Users.Where(s=>s.Type == request.Type.Value);

        var UserVMs = _mapper.Map<List<UserVM>>(Users.ToList());
        return Task.FromResult(UserVMs);
    }
}
