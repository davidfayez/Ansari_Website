
namespace Ansari_Website.Application.CPanel.Event.Queries.GetById;
public class GetEventByIdQuery : IRequest<DB.Event>
{
    public int Id { get; set; }
}

public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, DB.Event>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetEventByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var Event = _applicationDbContext.Events.Include(s => s.EventDetails).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Event != null)
            return Task.FromResult(Event);

        else
            return Task.FromResult(new DB.Event());

    }


}
