using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Question.Commands.Delete;

namespace Ansari_Website.Application.CPanel.Question.Commands.Delete;
public class DeleteQuestionCommand : IRequest<bool>, IMapFrom<DB.Question>
{
    public int Id { get; set; }
}

public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteQuestionCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var Question = _applicationDbContext.Questions.Find(request.Id);
            if (Question != null)
            {
                Question.IsDeleted = true;
                _applicationDbContext.Questions.Update(Question);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}


