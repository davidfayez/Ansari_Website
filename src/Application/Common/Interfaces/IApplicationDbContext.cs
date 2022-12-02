using Ansari_Website.Domain.Entities.Def;
using Ansari_Website.Domain.Entities.Identity;
using ERP.DAL.Domains.Authentication;
using ERP.DAL.Domains.Def;
using ERP.DAL.Domains;
using Ansari_Website.Domain.Entities.CPanel;

namespace Ansari_Website.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    #region Identity
    DbSet<ApplicationRole> AspNetRoles { get; }
    DbSet<AspNetUser> AspNetUsers { get; }
    DbSet<AspNetUserDefBranch> AspNetUserDefBranches { get; }
    DbSet<ApplicationUserRole> AspNetUserRoles { get; }
    DbSet<AuthenticationTickets> AuthenticationTickets { get; }
    #endregion

    #region Def
    DbSet<DefBranch> DefBranches { get; }
    DbSet<DefCity> DefCities { get; }
    DbSet<DefCompany> DefCompanies { get; }
    DbSet<DefCountry> DefCountries { get; }
    DbSet<DefCurrency> DefCurrencies { get; }
    DbSet<DefDocumentType> DefDocumentTypes { get; }
    DbSet<DefNationality> DefNationalities { get; }
    DbSet<DefReligion> DefReligions { get; }
    #endregion

    #region CPanel
    DbSet<AboutUs> AboutUs { get; }
    DbSet<SiteInfo> SiteInfo { get; }
    DbSet<Doctor> Doctors { get; }
    DbSet<Department> Departments { get; }

    #endregion

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
