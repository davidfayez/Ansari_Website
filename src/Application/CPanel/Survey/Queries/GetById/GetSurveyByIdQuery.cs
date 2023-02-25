using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Survey.Queries.GetById;

namespace Ansari_Website.Application.CPanel.Survey.Queries.GetById;
public class GetSurveyByIdQuery : IRequest<DB.Survey>
{
    public int Id { get; set; }
}

public class GetSurveyByIdQueryHandler : IRequestHandler<GetSurveyByIdQuery, DB.Survey>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetSurveyByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Survey> Handle(GetSurveyByIdQuery request, CancellationToken cancellationToken)
    {
        var Survey = _applicationDbContext.Surveys.Include(s=>s.SurveyQuestionAnswers)
            .ThenInclude(s=>s.Question)
            .Include(s => s.SurveyQuestionAnswers)
            .ThenInclude(s => s.Answer)
            .FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Survey != null)
            return Task.FromResult(Survey);
        else
            return Task.FromResult(new DB.Survey());

    }


}
