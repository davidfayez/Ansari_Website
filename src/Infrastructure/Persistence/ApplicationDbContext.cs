using System;
using System.Collections.Generic;
using Ansari_Website.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Ansari_Website.Domain.Interfaces;
using ERP.DAL.Domains;
using ERP.DAL.Domains.Authentication;
using Microsoft.AspNetCore.Identity;
using ERP.DAL.Domains.Def;
using System.Reflection;
using Ansari_Website.Domain.Entities.Def;
using Ansari_Website.Domain.Entities.Identity;
using Ansari_Website.Infrastructure.Persistence;
using Ansari_Website.Domain.Entities.CPanel;

namespace Ansari_Website.Infrastructure.Persistence;

public partial class ApplicationDbContext : IdentityDbContext<AspNetUser, ApplicationRole, string, IdentityUserClaim<string>,
                                                  ApplicationUserRole, IdentityUserLogin<string>,
                                                  IdentityRoleClaim<string>, IdentityUserToken<string>>, IApplicationDbContext
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;

    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        ICurrentUserService currentUserService,
            IDomainEventService domainEventService,
            IDateTime dateTime)
        : base(options)
    {
        _currentUserService = currentUserService;
        _dateTime = dateTime;
    }

    #region Identity
    public virtual DbSet<ApplicationRole> AspNetRoles => Set<ApplicationRole>();
    public virtual DbSet<AspNetUser> AspNetUsers => Set<AspNetUser>();
    public virtual DbSet<AspNetUserDefBranch> AspNetUserDefBranches => Set<AspNetUserDefBranch>();
    public virtual DbSet<ApplicationUserRole> AspNetUserRoles => Set<ApplicationUserRole>();
    public virtual DbSet<AuthenticationTickets> AuthenticationTickets => Set<AuthenticationTickets>();
    public virtual DbSet<UserOTP> UserOTPs => Set<UserOTP>();
    #endregion

    #region Def
    public virtual DbSet<DefBranch> DefBranches => Set<DefBranch>();
    public virtual DbSet<DefCity> DefCities => Set<DefCity>();
    public virtual DbSet<DefCompany> DefCompanies => Set<DefCompany>();
    public virtual DbSet<DefCountry> DefCountries => Set<DefCountry>();
    public virtual DbSet<DefCurrency> DefCurrencies => Set<DefCurrency>();
    public virtual DbSet<DefDocumentType> DefDocumentTypes => Set<DefDocumentType>();
    public virtual DbSet<DefNationality> DefNationalities => Set<DefNationality>();
    public virtual DbSet<DefReligion> DefReligions => Set<DefReligion>();
    #endregion

    #region CPanel
    public virtual DbSet<AboutUs> AboutUs => Set<AboutUs>();
    public virtual DbSet<SiteInfo> SiteInfo => Set<SiteInfo>();
    public virtual DbSet<Department> Departments => Set<Department>();
    public virtual DbSet<Doctor> Doctors => Set<Doctor>();
    public virtual DbSet<Partner> Partners => Set<Partner>();
    public virtual DbSet<Answer> Answers => Set<Answer>();
    public virtual DbSet<Question> Questions => Set<Question>();
    public virtual DbSet<QuestionAnswer> QuestionAnswers => Set<QuestionAnswer>();
    public virtual DbSet<Blog> Blogs => Set<Blog>();
    public virtual DbSet<Complaint> Complaints => Set<Complaint>();
    public virtual DbSet<EventDetail> EventDetails => Set<EventDetail>();
    public virtual DbSet<Event> Events => Set<Event>();
    public virtual DbSet<Offer> Offers => Set<Offer>();
    public virtual DbSet<OfferDetail> OfferDetails => Set<OfferDetail>();
    public virtual DbSet<OurValue> OurValues => Set<OurValue>();
    public virtual DbSet<OverView> OverViews => Set<OverView>();
    public virtual DbSet<OverViewDetail> OverViewDetails => Set<OverViewDetail>();
    public virtual DbSet<PatientRight> PatientRights => Set<PatientRight>();
    public virtual DbSet<PatientRightDetail> PatientRightDetails => Set<PatientRightDetail>();
    public virtual DbSet<PatientSay> PatientSays => Set<PatientSay>();
    public virtual DbSet<Testiminie> Testiminies => Set<Testiminie>();
    public virtual DbSet<TestiminieDetail> TestiminieDetails => Set<TestiminieDetail>();

    #endregion
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedUserId = _currentUserService.UserId;
                    entry.Entity.CreationDate = _dateTime.Now;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedUserId = _currentUserService.UserId;
                    entry.Entity.LastModifiedDate = _dateTime.Now;
                    break;

                case EntityState.Deleted:
                    entry.Entity.DeletedUserId = _currentUserService.UserId;
                    entry.Entity.LastModifiedDate = _dateTime.Now;
                    break;
            }
        }

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed();
    }
}
