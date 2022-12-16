using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Partner.Commands.Create;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.CPanel.Partner.Commands.Create;
public class CreateUpdatePartnerCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.Partner>
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile PartnerImage { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Partner, CreateUpdatePartnerCommand>()
               .ReverseMap();
    }
}

public class CreateUpdatePartnerCommandHandler : IRequestHandler<CreateUpdatePartnerCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdatePartnerCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdatePartnerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Partner = _mapper.Map<DB.Partner>(request);

            if (request.Id > 0)
                _applicationDbContext.Partners.Update(Partner);
            else
                _applicationDbContext.Partners.Add(Partner);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

