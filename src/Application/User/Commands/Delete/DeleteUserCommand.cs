using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DAL.Domains;

namespace Ansari_Website.Application.User.Commands.Delete;
public class DeleteUserCommand : IRequest<bool>, IMapFrom<AspNetUser>
{
    public string Id { get; set; }
}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.Id))
        {
            var User = _applicationDbContext.AspNetUsers.Find(request.Id);
            if (User != null)
            {
                User.IsDeleted = true;
                _applicationDbContext.AspNetUsers.Update(User);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}
