using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Answer.Queries.GetAll;
using ERP.DAL.Domains;
using Microsoft.AspNetCore.Identity;

namespace Ansari_Website.Application.User.VM;
public class UserVM : IdentityUser, IMapFrom<AspNetUser>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserVM, AspNetUser>()
               .ReverseMap();
    }
    public string FullName { get; set; }
    public string Image { get; set; }
    public string SurName { get; set; }
    public string Password { get; set; }
    public bool IsDeveloper { get; set; }
    public int? Type { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;   // تاريخ الادخال
    public DateTime LastModifiedDate { get; set; } = DateTime.Now;

}

