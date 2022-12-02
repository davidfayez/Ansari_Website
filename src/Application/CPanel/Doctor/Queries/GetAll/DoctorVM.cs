using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.Doctor.Queries.GetAll;
public class DoctorVM : AuditableEntity, IMapFrom<DB.Doctor>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DoctorVM, DB.Doctor>()
               .ReverseMap();
    }

    public int Id { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public string? DepartmentName { get; set; }
    public int DepartmentId { get; set; }
}
