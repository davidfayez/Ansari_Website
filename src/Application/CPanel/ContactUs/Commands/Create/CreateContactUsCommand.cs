using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.ContactUs.Commands.Create;
public class CreateContactUsCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.ContactUs>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public bool IsSeen { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.ContactUs, CreateContactUsCommand>()
               .ReverseMap();
    }
}

public class CreateContactUsCommandHandler : IRequestHandler<CreateContactUsCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateContactUsCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateContactUsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var ContactUs = _mapper.Map<DB.ContactUs>(request);
            _applicationDbContext.ContactUs.Add(ContactUs);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

