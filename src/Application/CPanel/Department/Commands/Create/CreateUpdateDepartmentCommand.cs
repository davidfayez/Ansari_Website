using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Department.Commands.Create;
using Ansari_Website.Application.CPanel.SiteInfo.Commands.Create;

namespace Ansari_Website.Application.CPanel.Department.Commands.Create;
public class CreateUpdateDepartmentCommand : AuditableEntity, IRequest<bool>, IMapFrom<DB.Department>
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUpdateDepartmentCommand, DB.Department>()
               .ReverseMap();
    }
}

public class CreateUpdateDepartmentCommandHandler : IRequestHandler<CreateUpdateDepartmentCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;

    public CreateUpdateDepartmentCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateUpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Department = _mapper.Map<DB.Department>(request);

            if (request.Id > 0)
                _applicationDbContext.Departments.Update(Department);
            else
                _applicationDbContext.Departments.Add(Department);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}

