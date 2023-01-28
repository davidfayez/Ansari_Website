using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DAL.Domains;

namespace Ansari_Website.Domain.Entities.Identity;
public class UserOTP : AuditableEntity
{
    public int Id { get; set; }
    public int OTP { get; set; }
    public string UserId { get; set; }
    public string Key { get; set; }
    public int ContactType { get; set; }
    public AspNetUser User { get; set; }

}
