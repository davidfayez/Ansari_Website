using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.Answer.Queries.GetAll;
public class GetAllAnswersQuery : IRequest<List<AnswerVM>>
{

}

public class GetAllAnswersQueryHandler : IRequestHandler<GetAllAnswersQuery, List<AnswerVM>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public GetAllAnswersQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public Task<List<AnswerVM>> Handle(GetAllAnswersQuery request, CancellationToken cancellationToken)
    {
        var Answers = _applicationDbContext.Answers.Where(s => !s.IsDeleted);

        var AnswerVMs = _mapper.Map<List<AnswerVM>>(Answers.ToList());
        return Task.FromResult(AnswerVMs);
    }
}

