
namespace Ansari_Website.Application.CPanel.AboutUs.Queries.GetById;
public class GetAboutUsQuery : IRequest<DB.AboutUs>
{
}

public class GetAboutUsQueryHandler : IRequestHandler<GetAboutUsQuery, DB.AboutUs>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAboutUsQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.AboutUs> Handle(GetAboutUsQuery request, CancellationToken cancellationToken)
    {
        var AboutUs = _applicationDbContext.AboutUs.FirstOrDefault();

        if (AboutUs != null)
            return Task.FromResult(AboutUs);
        else
            return Task.FromResult(new DB.AboutUs());
    }


}

