
namespace Ansari_Website.Application.CPanel.PatientRight.Commands.CreateDetail;
public class CreateUpdatePatientRightDetailCommand : IRequest<bool>, IMapFrom<DB.PatientRightDetail>
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public int PatientRightId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.PatientRightDetail, CreateUpdatePatientRightDetailCommand>()
               .ReverseMap();
    }
}

public class CreateUpdatePatientRightDetailCommandHandler : IRequestHandler<CreateUpdatePatientRightDetailCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdatePatientRightDetailCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdatePatientRightDetailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var PatientRight = _mapper.Map<DB.PatientRightDetail>(request);

            if (request.Id > 0)
                _applicationDbContext.PatientRightDetails.Update(PatientRight);
            else
                _applicationDbContext.PatientRightDetails.Add(PatientRight);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}


