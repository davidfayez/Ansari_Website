using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.CPanel;
public class Complaint : AuditableEntity
{
    public int Id { get; set; }
    public int ComplaintNo { get; set; }
    public string? ComplaintMessage { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsSeen { get; set; }
}
