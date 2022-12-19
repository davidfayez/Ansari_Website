using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.SurveyQuestion.Queries.GetById;

namespace Ansari_Website.Application.CPanel.SurveyQuestion.Queries.GetById;
public class GetSurveyQuestionByIdQuery : IRequest<DB.Question>
{
    public int Id { get; set; }
}

public class GetSurveyQuestionByIdQueryHandler : IRequestHandler<GetSurveyQuestionByIdQuery, DB.Question>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetSurveyQuestionByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Question> Handle(GetSurveyQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var SurveyQuestion = _applicationDbContext.SurveyQuestions.FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (SurveyQuestion != null)
            return Task.FromResult(SurveyQuestion);

        else
            return Task.FromResult(new DB.Question());

    }


}
