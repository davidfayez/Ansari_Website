
using Ansari_Website.Application.CPanel.AboutUs.Queries.GetAll;
using Ansari_Website.Domain.Entities.CPanel;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.CPanel.AboutUs.Commands.Create;
public class CreateUpdateAboutUsCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.AboutUs>
{
    public int Id { get; set; }

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
    public List<OurValueVM> OurValueVMs { get; set; } = new();

    #endregion

    #region Picture
    public string? ImageUrl { get; set; }
    public IFormFile AboutUsImage { get; set; }

    #endregion

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUpdateAboutUsCommand, DB.AboutUs>()
                .ForMember(des => des.OurValues, opt => opt.MapFrom(src => src.OurValueVMs))
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


