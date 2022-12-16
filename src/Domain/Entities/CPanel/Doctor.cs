using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.CPanel;
public class Doctor : AuditableEntity
{
    public int Id { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public string? ImageUrl { get; set; }
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }
}
