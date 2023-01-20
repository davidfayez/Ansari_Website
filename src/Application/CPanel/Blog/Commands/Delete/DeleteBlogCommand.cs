using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Blog.Commands.Delete;

namespace Ansari_Website.Application.CPanel.Blog.Commands.Delete;
public class DeleteBlogCommand : IRequest<bool>, IMapFrom<DB.Blog>
{
    public int Id { get; set; }
}

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public DeleteBlogCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        if (request.Id > 0)
        {
            var Blog = _applicationDbContext.Blogs.Find(request.Id);
            if (Blog != null)
            {
                Blog.IsDeleted = true;
                _applicationDbContext.Blogs.Update(Blog);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return await Task.FromResult(true);
            }
        }
        return await Task.FromResult(false);
    }
}
