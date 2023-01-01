using Ansari_Website.Application.CPanel.Event.VM;

namespace Ansari_Website.Application.CPanel.Event.Queries.GetAll;
public class GetAllEventsQuery : IRequest<List<EventVM>>
{

}

public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, List<EventVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllEventsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<EventVM>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        var Events = _applicationDbContext.Events.Where(s => !s.IsDeleted);

        var EventVMs = _mapper.Map<List<EventVM>>(Events.ToList());
        return Task.FromResult(EventVMs);
    }
}
