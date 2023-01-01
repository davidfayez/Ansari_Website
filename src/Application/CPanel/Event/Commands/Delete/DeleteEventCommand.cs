
namespace Ansari_Website.Application.CPanel.Event.Commands.Delete;
public class DeleteEventCommand : IRequest<bool>, IMapFrom<DB.Event>
{
    public int Id { get; set; }
}

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteEventCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var Event = _applicationDbContext.Events.Find(request.Id);
            if (Event != null)
            {
                Event.IsDeleted = true;
                _applicationDbContext.Events.Update(Event);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}