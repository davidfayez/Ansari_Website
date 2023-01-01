using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.Question.Queries.GetById;
public class GetQuestionByIdQuery : IRequest<DB.Question>
{
    public int Id { get; set; }
}

public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, DB.Question>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetQuestionByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Question> Handle(GetQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var Question = _applicationDbContext.Questions.Include(s=>s.QuestionAnswers).FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Question != null)
            return Task.FromResult(Question);

        else
            return Task.FromResult(new DB.Question());

    }


}

