using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Queries.GetById;

namespace Ansari_Website.Application.CPanel.Answer.Queries.GetById;
public class GetAnswerByIdQuery : IRequest<DB.Answer>
{
    public int Id { get; set; }
}

public class GetAnswerByIdQueryHandler : IRequestHandler<GetAnswerByIdQuery, DB.Answer>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAnswerByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Answer> Handle(GetAnswerByIdQuery request, CancellationToken cancellationToken)
    {
        var Answer = _applicationDbContext.Answers.FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Answer != null)
            return Task.FromResult(Answer);

        else
            return Task.FromResult(new DB.Answer());

    }


}

