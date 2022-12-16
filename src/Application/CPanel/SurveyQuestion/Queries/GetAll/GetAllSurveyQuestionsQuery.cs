using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.SurveyQuestion.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.SurveyQuestion.Queries.GetAll;
public class GetAllSurveyQuestionsQuery : IRequest<List<SurveyQuestionVM>>
{

}

public class GetAllSurveyQuestionsQueryHandler : IRequestHandler<GetAllSurveyQuestionsQuery, List<SurveyQuestionVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllSurveyQuestionsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<SurveyQuestionVM>> Handle(GetAllSurveyQuestionsQuery request, CancellationToken cancellationToken)
    {
        var SurveyQuestions = _applicationDbContext.SurveyQuestions.Where(s => !s.IsDeleted);

        var SurveyQuestionVMs = _mapper.Map<List<SurveyQuestionVM>>(SurveyQuestions.ToList());
        return Task.FromResult(SurveyQuestionVMs);
    }
}

