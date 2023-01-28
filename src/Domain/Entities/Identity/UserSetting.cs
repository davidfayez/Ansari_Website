using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DAL.Domains;

namespace Ansari_Website.Domain.Entities.Identity;
public class UserSetting : AuditableEntity
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public AspNetUser User { get; set; }
    public int AppSettingId { get; set; }
    public bool Status { get; set; }
    public AppSetting AppSetting { get; set; }
}
