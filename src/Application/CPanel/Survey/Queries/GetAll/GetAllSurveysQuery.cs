using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Survey.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.Survey.Queries.GetAll;
public class GetAllSurveysQuery : IRequest<List<SurveyVM>>
{

}

public class GetAllSurveysQueryHandler : IRequestHandler<GetAllSurveysQuery, List<SurveyVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllSurveysQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<SurveyVM>> Handle(GetAllSurveysQuery request, CancellationToken cancellationToken)
    {
        var Surveys = _applicationDbContext.Surveys.Where(s => !s.IsDeleted);

        var SurveyVMs = _mapper.Map<List<SurveyVM>>(Surveys.ToList());
        return Task.FromResult(SurveyVMs);
    }
}
