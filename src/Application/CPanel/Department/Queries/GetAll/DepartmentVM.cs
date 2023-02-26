using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Doctor.Queries.GetAll;
using Ansari_Website.Domain.Enums;

namespace Ansari_Website.Application.CPanel.Department.Queries.GetAll;
public class DepartmentVM : IMapFrom<DB.Department>
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
    public string? ImageUrl { get; set; }
    public string? AltImage { get; set; }
    public string? IconUrl { get; set; }
    public Speciality Speciality { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsSystem { get; set; }                  // تم الادخال من الشاشات أم قاعدة البيانات
    public DateTime CreationDate { get; set; }         // تاريخ الادخال
    public DateTime LastModifiedDate { get; set; }
}
