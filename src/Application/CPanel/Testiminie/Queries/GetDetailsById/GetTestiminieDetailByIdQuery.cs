using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.Testiminie.Queries.GetDetailsById;
public class GetTestiminieDetailByIdQuery : IRequest<DB.TestiminieDetail>
{
    public int Id { get; set; }
}

public class GetTestiminieDetailByIdQueryHandler : IRequestHandler<GetTestiminieDetailByIdQuery, DB.TestiminieDetail>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetTestiminieDetailByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public Task<DB.TestiminieDetail> Handle(GetTestiminieDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var TestiminieDetail = _applicationDbContext.TestiminieDetails.FirstOrDefault(s => s.Id == request.Id);

        if (TestiminieDetail != null)
        {
            TestiminieDetail.ImageUrl = TestiminieDetail.ImageUrl != null ? "Testiminies/" + TestiminieDetail.ImageUrl : "Users/profile-icon.jpg";

            return Task.FromResult(TestiminieDetail);
        }
        else
            return Task.FromResult(new DB.TestiminieDetail());

    }


}