using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.PatientRight.VM;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.CPanel.PatientRight.Commands.Create;
public class CreateUpdatePatientRightCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.PatientRight>
{
    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
    public string? AltImage { get; set; }
    public IFormFile PatientRightImage { get; set; }
    public List<PatientRightDetailVM> PatientRightDetailVMs { get; set; } = new();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.PatientRight, CreateUpdatePatientRightCommand>()
                .ForMember(des => des.PatientRightDetailVMs, opt => opt.MapFrom(src => src.PatientRightDetails))
               .ReverseMap();

        profile.CreateMap<DB.PatientRightDetail, PatientRightDetailVM>()
               .ReverseMap();
    }
}

public class CreateUpdatePatientRightCommandHandler : IRequestHandler<CreateUpdatePatientRightCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdatePatientRightCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdatePatientRightCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var PatientRight = _mapper.Map<DB.PatientRight>(request);

            if (request.Id > 0)
                _applicationDbContext.PatientRights.Update(PatientRight);
            else
                _applicationDbContext.PatientRights.Add(PatientRight);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

