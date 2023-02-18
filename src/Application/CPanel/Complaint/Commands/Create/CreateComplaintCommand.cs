using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Complaint.Commands.Create;

namespace Ansari_Website.Application.CPanel.Complaint.Commands.Create;
public class CreateComplaintCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.Complaint>
{
    public int Id { get; set; }
    public int ComplaintNo { get; set; }
    public string? ComplaintMessage { get; set; }
    public string? PhoneNumber { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Complaint, CreateComplaintCommand>()
               .ReverseMap();
    }
}


public class CreateComplaintCommandHandler : IRequestHandler<CreateComplaintCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateComplaintCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateComplaintCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Complaint = _mapper.Map<DB.Complaint>(request);

            if (request.Id > 0)
                _applicationDbContext.Complaints.Update(Complaint);
            else
                _applicationDbContext.Complaints.Add(Complaint);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

