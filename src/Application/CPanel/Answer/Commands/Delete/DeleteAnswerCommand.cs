using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Commands.Delete;

namespace Ansari_Website.Application.CPanel.Answer.Commands.Delete;
public class DeleteAnswerCommand : IRequest<bool>, IMapFrom<DB.Answer>
{
    public int Id { get; set; }
}

public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteAnswerCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var Answer = _applicationDbContext.Answers.Find(request.Id);
            if (Answer != null)
            {
                Answer.IsDeleted = true;
                //_applicationDbContext.Answers.Update(Answer);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}



