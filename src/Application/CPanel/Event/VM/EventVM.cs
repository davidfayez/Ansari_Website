
namespace Ansari_Website.Application.CPanel.Event.VM;
public class EventVM : AuditableEntity, IMapFrom<DB.Event>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<EventVM, DB.Event>()
               .ReverseMap();
    }
    public int Id { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
}
