using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ansari_Website.Application.CPanel.Blog.Commands.Create;
public class CreateUpdateBlogCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.Blog>
{
    
    public int Id { get; set; }
    public int? Order { get; set; }
    public int DepartmentId { get; set; }
    public string DoctorId { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
    public string? AltImage { get; set; }
    public List<SelectListItem> Doctors { get; set; } = new();
    public List<SelectListItem> Departments { get; set; } = new();
    public IFormFile BlogImage { get; set; }


    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Blog, CreateUpdateBlogCommand>()
               .ReverseMap();
    }
}

public class CreateUpdateBlogCommandHandler : IRequestHandler<CreateUpdateBlogCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateBlogCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateBlogCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Blog = _mapper.Map<DB.Blog>(request);

            if (request.Id > 0)
                _applicationDbContext.Blogs.Update(Blog);
            else
                _applicationDbContext.Blogs.Add(Blog);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

