using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansari_Website.Domain.Entities.CPanel;
public class TestiminieDetail
{
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? ImageUrl { get; set; }
    public int TestiminieId { get; set; }
    public virtual Testiminie Testiminie { get; set; }

}
