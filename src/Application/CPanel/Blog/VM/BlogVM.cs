namespace Ansari_Website.Application.CPanel.Blog.VM;
public class BlogVM : AuditableEntity, IMapFrom<DB.Blog>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<DB.Blog, BlogVM>()
               .ForMember(des => des.DepartmentName, opt => opt.MapFrom(src => src.Department.TitleAr))
               .ForMember(des => des.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName))
               .ReverseMap();
    }

    public int Id { get; set; }
    public int? Order { get; set; }
    public int DepartmentId { get; set; }
    public int DoctorId { get; set; }
    public string? TitleAr { get; set; }
    public string? TitleEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public string? ImageUrl { get; set; }
    public string? AltImage { get; set; }
    public string DepartmentName { get; private set; }
    public string DoctorName { get; private set; }
}
