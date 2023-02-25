using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Complaint.Commands.Create;

namespace Ansari_Website.Application.CPanel.Complaint.Commands.IsSeen;
public class IsComplaintSeenCommand : IRequest<bool>
{
    public int Id { get; set; }

}

public class IsComplaintSeenCommandHandler : IRequestHandler<IsComplaintSeenCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public IsComplaintSeenCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(IsComplaintSeenCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Complaint = _applicationDbContext.Complaints.Find(request.Id);
            if(Complaint != null )
            {
                Complaint.IsSeen = true;
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

