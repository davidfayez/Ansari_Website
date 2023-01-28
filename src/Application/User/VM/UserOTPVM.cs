using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.User.VM;
public class UserOTPVM
{
    public int Id { get; set; }
    public int OTP { get; set; }
    public string UserId { get; set; }
    public string Key { get; set; }
    public int ContactType { get; set; }
}
