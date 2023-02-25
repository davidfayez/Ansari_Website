using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ansari_Website.Application.User.Commands.Create;
using Ansari_Website.Application.User.VM;
using Ansari_Website.Domain.Entities.Identity;
using ERP.DAL.Domains;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ansari_Website.Application.User.Commands.Login;
public class LoginViaEmailCommand : IRequest<UserVM>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
    public int? Type { get; set; }
}


public class LoginViaEmailCommandHandler : IRequestHandler<LoginViaEmailCommand, UserVM>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    private readonly UserManager<AspNetUser> _userManager;

    public LoginViaEmailCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper, UserManager<AspNetUser> userManager)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task<UserVM> Handle(LoginViaEmailCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _applicationDbContext.AspNetUsers.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user != null && request.Password == user.Password)
            {
                return await Task.FromResult(_mapper.Map<UserVM>(user));
            }
            return await Task.FromResult(new UserVM());
        }
        catch (Exception ex)
        {
            return await Task.FromResult(new UserVM());
        }

    }
}
