using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Question.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.Question.Queries.GetAll;
public class GetAllQuestionsQuery : IRequest<List<QuestionVM>>
{

}

public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, List<QuestionVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllQuestionsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<QuestionVM>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
    {
        var Questions = _applicationDbContext.Questions.Where(s => !s.IsDeleted);

        var QuestionVMs = _mapper.Map<List<QuestionVM>>(Questions.ToList());
        return Task.FromResult(QuestionVMs);
    }
}

