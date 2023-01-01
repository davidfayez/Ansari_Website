
namespace Ansari_Website.Application.CPanel.PatientRight.Queries.GetById;
public class GetPatientRightByIdQuery : IRequest<DB.PatientRight>
{
    public int Id { get; set; }
}

public class GetPatientRightByIdQueryHandler : IRequestHandler<GetPatientRightByIdQuery, DB.PatientRight>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetPatientRightByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.PatientRight> Handle(GetPatientRightByIdQuery request, CancellationToken cancellationToken)
    {
        var PatientRight = _applicationDbContext.PatientRights.Include(s => s.PatientRightDetails).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (PatientRight != null)
            return Task.FromResult(PatientRight);

        else
            return Task.FromResult(new DB.PatientRight());

    }


}