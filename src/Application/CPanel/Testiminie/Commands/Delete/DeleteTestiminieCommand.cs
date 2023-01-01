using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Testiminie.Commands.Delete;

namespace Ansari_Website.Application.CPanel.Testiminie.Commands.Delete;
public class DeleteTestiminieCommand : IRequest<bool>, IMapFrom<DB.Testiminie>
{
    public int Id { get; set; }
}

public class DeleteTestiminieCommandHandler : IRequestHandler<DeleteTestiminieCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteTestiminieCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteTestiminieCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var Testiminie = _applicationDbContext.Testiminies.Find(request.Id);
            if (Testiminie != null)
            {
                Testiminie.IsDeleted = true;
                _applicationDbContext.Testiminies.Update(Testiminie);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}
