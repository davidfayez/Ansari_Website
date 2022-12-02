
namespace Ansari_Website.Application.CPanel.SiteInfo.Queries.GetById;
public class GetSiteInfoQuery : IRequest<DB.SiteInfo>
{

}

public class GetSiteInfoQueryHandler : IRequestHandler<GetSiteInfoQuery, DB.SiteInfo>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetSiteInfoQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.SiteInfo> Handle(GetSiteInfoQuery request, CancellationToken cancellationToken)
    {
        var SiteInfo = _applicationDbContext.SiteInfo.FirstOrDefault();

        if (SiteInfo != null)
            return Task.FromResult(SiteInfo);
        else
            return Task.FromResult(new DB.SiteInfo());
    }


}

