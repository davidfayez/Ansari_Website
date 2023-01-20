using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Application.CPanel.Complaint.Queries.GetAll;
public class ComplaintVM : AuditableEntity, IMapFrom<DB.Complaint>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ComplaintVM, DB.Complaint>()
               .ReverseMap();
    }

    public int Id { get; set; }
    public int ComplaintNo { get; set; }
    public string? ComplaintMessage { get; set; }
    public string? PhoneNumber { get; set; }
    public bool IsSeen { get; set; }

}
