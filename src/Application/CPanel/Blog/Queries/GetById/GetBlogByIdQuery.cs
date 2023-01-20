namespace Ansari_Website.Application.CPanel.Blog.Queries.GetById;
public class GetBlogByIdQuery : IRequest<DB.Blog>
{
    public int Id { get; set; }
}

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, DB.Blog>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetBlogByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.Blog> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var Blog = _applicationDbContext.Blogs.FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);

        if (Blog != null)
            return Task.FromResult(Blog);

        else
            return Task.FromResult(new DB.Blog());
    }
}
