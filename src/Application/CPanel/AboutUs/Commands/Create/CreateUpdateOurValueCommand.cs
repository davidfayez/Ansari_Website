using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Offer.Commands.Create;

namespace Ansari_Website.Application.CPanel.AboutUs.Commands.Create;
public class CreateUpdateOurValueCommand : IRequest<bool>, IMapFrom<DB.OurValue>
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? IconName { get; set; }
    public int AboutUsId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.OurValue, CreateUpdateOurValueCommand>()
               .ReverseMap();
    }
}

public class CreateUpdateOurValueCommandHandler : IRequestHandler<CreateUpdateOurValueCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateOurValueCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateOurValueCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var OurValue = _mapper.Map<DB.OurValue>(request);

            if (request.Id > 0)
                _applicationDbContext.OurValues.Update(OurValue);
            else
                _applicationDbContext.OurValues.Add(OurValue);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

