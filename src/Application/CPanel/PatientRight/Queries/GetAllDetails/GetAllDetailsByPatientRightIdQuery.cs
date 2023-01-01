
namespace Ansari_Website.Application.CPanel.PatientRight.Queries.GetAllDetails;
public class GetAllDetailsByPatientRightIdQuery : IRequest<List<DB.PatientRightDetail>>
{
    public int Id { get; set; }
}

public class GetAllDetailsByPatientRightIdQueryHandler : IRequestHandler<GetAllDetailsByPatientRightIdQuery, List<DB.PatientRightDetail>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllDetailsByPatientRightIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<List<DB.PatientRightDetail>> Handle(GetAllDetailsByPatientRightIdQuery request, CancellationToken cancellationToken)
    {
        var PatientRight = _applicationDbContext.PatientRights.Include(s => s.PatientRightDetails).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (PatientRight != null)
            return Task.FromResult(PatientRight.PatientRightDetails.ToList());

        else
            return Task.FromResult(new List<DB.PatientRightDetail>());

    }


}