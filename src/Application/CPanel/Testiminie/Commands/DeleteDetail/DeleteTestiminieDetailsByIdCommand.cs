using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Testiminie.Commands.DeleteDetail;

namespace Ansari_Website.Application.CPanel.Testiminie.Commands.DeleteDetail;
public class DeleteTestiminieDetailsByIdCommand : IRequest<bool>, IMapFrom<DB.TestiminieDetail>
{
    public int Id { get; set; }
}


public class DeleteTestiminieDetailsByIdCommandHandler : IRequestHandler<DeleteTestiminieDetailsByIdCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteTestiminieDetailsByIdCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteTestiminieDetailsByIdCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var TestiminieDetail = _applicationDbContext.TestiminieDetails.Find(request.Id);
            if (TestiminieDetail != null)
            {
                //TestiminieDetail.IsDeleted = true;
                _applicationDbContext.TestiminieDetails.Remove(TestiminieDetail);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}