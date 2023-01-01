
namespace Ansari_Website.Application.CPanel.Event.Commands.DeleteDetail;
public class DeleteEventDetailsByIdCommand : IRequest<bool>, IMapFrom<DB.EventDetail>
{
    public int Id { get; set; }
}


public class DeleteEventDetailsByIdCommandHandler : IRequestHandler<DeleteEventDetailsByIdCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteEventDetailsByIdCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteEventDetailsByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var EventDetail = _applicationDbContext.EventDetails.Find(request.Id);
            if (EventDetail != null)
            {
                //EventDetail.IsDeleted = true;
                _applicationDbContext.EventDetails.Remove(EventDetail);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}