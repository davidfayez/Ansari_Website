using Ansari_Website.Domain.Entities.Def;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ansari_Website.Domain.Entities.Identity;

[Table("AspNetUserRoles")]
public class ApplicationUserRole : IdentityUserRole<string>
{
    public int DefBranchId { get; set; }
    public virtual DefBranch DefBranch { get; set; }
}

