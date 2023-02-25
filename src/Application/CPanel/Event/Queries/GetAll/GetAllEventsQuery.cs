using Ansari_Website.Application.CPanel.Event.VM;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.CPanel.Event.Queries.GetAll;
public class GetAllEventsQuery : IRequest<List<EventVM>>
{
    public int LangId { get; set; }
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

        //var EventVMs = _mapper.Map<List<EventVM>>(Events.ToList());
        var EventVMs = Events.Select(s => new EventVM
        {
            Id = s.Id,
            DescriptionAr = s.DescriptionAr,
            DescriptionEn = s.DescriptionEn,
            TitleAr = s.TitleAr,
            TitleEn = s.TitleEn,
            ImageUrl = s.ImageUrl,
            Title = (request.LangId == (int)ELanguages.AR) ? s.TitleAr : s.TitleEn,
            Description = (request.LangId == (int)ELanguages.AR) ? s.DescriptionAr : s.DescriptionEn,
            EventDetailVMs = s.EventDetails.Select(x=>new EventDetailVM 
            { 
                Id = x.Id,
                TitleAr= x.TitleAr,
                EventId= x.EventId,
                ImageUrls= x.ImageUrls,
                Order= x.Order,
                TitleEn= x.TitleEn,
                Title = (request.LangId == (int)ELanguages.AR) ? x.TitleAr : x.TitleEn,
            }).ToList()
            
        }).ToList();
        return Task.FromResult(EventVMs);
    }
}
