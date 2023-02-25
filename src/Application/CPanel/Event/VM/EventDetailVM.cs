using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ansari_Website.Application.CPanel.Event.VM;
using Microsoft.AspNetCore.Http;

namespace Ansari_Website.Application.CPanel.Event.VM;
public class EventDetailVM : IMapFrom<DB.EventDetail>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<EventDetailVM, DB.EventDetail>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public int? Order { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? Title { get; set; }
    public string? ImageUrls { get; set; }
    public List<IFormFile> EventDetailImages { get; set; }
    public int EventId { get; set; }
}
