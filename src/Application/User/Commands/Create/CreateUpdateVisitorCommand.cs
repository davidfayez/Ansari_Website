using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.DAL.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Ansari_Website.Application.User.Commands.Create;
public class CreateUpdateVisitorCommand : IdentityUser, IRequest<bool>, IMapFrom<AspNetUser>
{
    public string FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string Password { get; set; }
    public bool IsDeveloper { get; set; }
    public bool IsNew { get; set; }
    public int? Type { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;   // تاريخ الادخال
    public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AspNetUser, CreateUpdateVisitorCommand>()
               .ReverseMap();
    }
}

public class CreateUpdateVisitorCommandHandler : IRequestHandler<CreateUpdateVisitorCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    private readonly UserManager<AspNetUser> _userManager;

    public CreateUpdateVisitorCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, UserManager<AspNetUser> userManager)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<bool> Handle(CreateUpdateVisitorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var User = _mapper.Map<AspNetUser>(request);

            if (!request.IsNew)
            {
                var user = await _userManager.FindByIdAsync(request.Id);
                user = _mapper.Map(request, user);
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, user.Password);
                var result = await _userManager.UpdateAsync(user);
            }
            else
                _applicationDbContext.AspNetUsers.Add(User);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(true);
        }
        catch (Exception ex)
        {
            return await Task.FromResult(false);
        }

    }
}