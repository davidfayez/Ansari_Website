using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DAL.Domains;

namespace Ansari_Website.Domain.Entities.CPanel;
public class Department 
{
    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public virtual IList<AspNetUser> Doctors { get; set; }
    public string? ImageUrl { get; set; }
    public string? AltImage { get; set; }
    public string? IconUrl { get; set; }
    public Speciality Speciality { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsSystem { get; set; }                  // تم الادخال من الشاشات أم قاعدة البيانات
    public DateTime CreationDate { get; set; }         // تاريخ الادخال
    public DateTime LastModifiedDate { get; set; }
    public virtual IList<Blog> Blogs { get; set; }
}
