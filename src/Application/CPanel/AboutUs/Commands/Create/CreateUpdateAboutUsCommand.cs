
namespace Ansari_Website.Application.CPanel.AboutUs.Commands.Create;
public class CreateUpdateAboutUsCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.AboutUs>
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }

    #region Our Mission
    public string? MissionTitleAr { get; set; }
    public string? MissionTitleEn { get; set; }
    public string? MissionIconName { get; set; }
    public string? MissionDescriptionAr { get; set; }
    public string? MissionDescriptionEn { get; set; }
    #endregion

    #region Our Vision
    public string? VisionTitleAr { get; set; }
    public string? VisionTitleEn { get; set; }
    public string? VisionIconName { get; set; }
    public string? VisionDescriptionAr { get; set; }
    public string? VisionDescriptionEn { get; set; }
    #endregion

    #region Our Value
    public string? ValueTitleAr { get; set; }
    public string? ValueTitleEn { get; set; }
    public string? ValueIconName { get; set; }
    public string? ValueDescriptionAr { get; set; }
    public string? ValueDescriptionEn { get; set; }
    #endregion

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUpdateAboutUsCommand, DB.AboutUs>()
               .ReverseMap();
    }
}

public class CreateUpdateAboutUsCommandHandler : IRequestHandler<CreateUpdateAboutUsCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateAboutUsCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateAboutUsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var IsAboutUsExist = _applicationDbContext.AboutUs.Any();
            var AboutUs = _mapper.Map<DB.AboutUs>(request);

            if(IsAboutUsExist)
                _applicationDbContext.AboutUs.Update(AboutUs);
            else
                _applicationDbContext.AboutUs.Add(AboutUs);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}


