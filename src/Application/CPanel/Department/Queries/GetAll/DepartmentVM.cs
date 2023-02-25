using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Doctor.Queries.GetAll;

namespace Ansari_Website.Application.CPanel.Department.Queries.GetAll;
public class DepartmentVM : AuditableEntity, IMapFrom<DB.Department>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DepartmentVM, DB.Department>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}
