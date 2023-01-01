
namespace Ansari_Website.Application.CPanel.PatientRight.Queries.GetDetailById;
public class GetPatientRightDetailByIdQuery : IRequest<DB.PatientRightDetail>
{
    public int Id { get; set; }
}

public class GetPatientRightDetailByIdQueryHandler : IRequestHandler<GetPatientRightDetailByIdQuery, DB.PatientRightDetail>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetPatientRightDetailByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.PatientRightDetail> Handle(GetPatientRightDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var PatientRightDetail = _applicationDbContext.PatientRightDetails.FirstOrDefault(s => s.Id == request.Id);

        if (PatientRightDetail != null)
            return Task.FromResult(PatientRightDetail);

        else
            return Task.FromResult(new DB.PatientRightDetail());

    }


}