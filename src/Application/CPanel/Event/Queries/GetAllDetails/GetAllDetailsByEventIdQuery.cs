
namespace Ansari_Website.Application.CPanel.Event.Queries.GetAllDetails;
public class GetAllDetailsByEventIdQuery : IRequest<List<DB.EventDetail>>
{
    public int Id { get; set; }
}

public class GetAllDetailsByEventIdQueryHandler : IRequestHandler<GetAllDetailsByEventIdQuery, List<DB.EventDetail>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllDetailsByEventIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<List<DB.EventDetail>> Handle(GetAllDetailsByEventIdQuery request, CancellationToken cancellationToken)
    {
        var Event = _applicationDbContext.Events.Include(s => s.EventDetails).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Event != null)
            return Task.FromResult(Event.EventDetails.ToList());

        else
            return Task.FromResult(new List<DB.EventDetail>());

    }


}
