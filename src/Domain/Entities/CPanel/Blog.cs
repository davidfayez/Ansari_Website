using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DAL.Domains;

namespace Ansari_Website.Domain.Entities.CPanel;
public class Blog /*: AuditableEntity*/
{
    public int Id { get; set; }
    public int? Order { get; set; }
    public int DepartmentId { get; set; }
    public string? DoctorId { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
    public string? AltImage { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;        // تاريخ الادخال
    public DateTime LastModifiedDate { get; set; }
    public virtual Department? Department { get; set; }
    public virtual AspNetUser? Doctor { get; set; }


}
