
namespace Ansari_Website.Application.CPanel.SiteInfo.Commands.Create;
public class CreateUpdateSiteInfoCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.SiteInfo>
{
    public int Id { get; set; }
    public string? FacebookLink { get; set; }
    public string? TwitterLink { get; set; }
    public string? InstgramLink { get; set; }
    public string? Youtube { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? AddressAr { get; set; }
    public string? AddressEn { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUpdateSiteInfoCommand, DB.SiteInfo>()
               .ReverseMap();
    }
}

public class CreateUpdateSiteInfoCommandHandler : IRequestHandler<CreateUpdateSiteInfoCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateSiteInfoCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateSiteInfoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var IsSiteInfoExist = _applicationDbContext.SiteInfo.Any();
            var SiteInfo = _mapper.Map<DB.SiteInfo>(request);

            if (IsSiteInfoExist)
                _applicationDbContext.SiteInfo.Update(SiteInfo);
            else
                _applicationDbContext.SiteInfo.Add(SiteInfo);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

