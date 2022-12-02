using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.CPanel;
public class SiteInfo : AuditableEntity
{
    public int Id { get; set; }
    public string? FacebookLink { get; set; }
    public string? TwitterLink { get; set; }
    public string? InstgramLink { get; set; }
    public string? Youtube { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? AddressAr { get; set; }
    public string? AddressEn { get; set; }
}
