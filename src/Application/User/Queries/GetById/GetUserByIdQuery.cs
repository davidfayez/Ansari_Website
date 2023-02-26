using Ansari_Website.Domain.Entities.CPanel;
using ERP.DAL.Domains;

namespace Ansari_Website.Application.User.Queries.GetById;
public class GetUserByIdQuery : IRequest<AspNetUser>
{
    public string Id { get; set; }
}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, AspNetUser>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetUserByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<AspNetUser> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var User = _applicationDbContext.AspNetUsers.FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (User != null)
        {
            User.Image = User.Image != null ? User.Image : "Users/profile-icon.jpg";
            return Task.FromResult(User);
        }
        else
            return Task.FromResult(new AspNetUser());

    }


}
