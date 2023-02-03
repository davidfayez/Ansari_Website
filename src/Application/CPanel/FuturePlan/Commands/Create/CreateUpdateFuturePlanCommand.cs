using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.FuturePlan.Commands.Create;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.CPanel.FuturePlan.Commands.Create;
public class CreateUpdateFuturePlanCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.FuturePlan>
{
    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
    public string? AltImage { get; set; }
    public IFormFile FuturePlanImage { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.FuturePlan, CreateUpdateFuturePlanCommand>()
               .ReverseMap();
    }
}

public class CreateUpdateFuturePlanCommandHandler : IRequestHandler<CreateUpdateFuturePlanCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateFuturePlanCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateFuturePlanCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var FuturePlan = _mapper.Map<DB.FuturePlan>(request);

            if (request.Id > 0)
                _applicationDbContext.FuturePlans.Update(FuturePlan);
            else
                _applicationDbContext.FuturePlans.Add(FuturePlan);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}
