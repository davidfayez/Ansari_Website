using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.ContactUs.Commands.IsSeen;

namespace Ansari_Website.Application.CPanel.ContactUs.Commands.IsSeen;
public class IsContactUsSeenCommand : IRequest<bool>
{
    public int Id { get; set; }
}

public class IsContactUsSeenCommandHandler : IRequestHandler<IsContactUsSeenCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public IsContactUsSeenCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(IsContactUsSeenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var ContactUs = _applicationDbContext.ContactUs.Find(request.Id);
            if (ContactUs != null)
            {
                ContactUs.IsSeen = true;
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }
    }
}


