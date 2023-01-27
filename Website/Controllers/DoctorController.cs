using Ansari_Website.Application.Common.Interfaces;
using Ansari_Website.Application.CPanel.Doctor.Queries.GetAll;
using Ansari_Website.Application.User.Queries.GetAll;
using Ansari_Website.Domain.Enums;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers;
public class DoctorController : BaseController
{
    private readonly IMapper _mapper;
    private readonly IFileHandler _fileHandler;

    public DoctorController(IMapper mapper, IFileHandler fileHandler)
    {
        _mapper = mapper;
        _fileHandler = fileHandler;
    }

    public async Task<IActionResult> IndexAsync()
    {
        //var doctors = await Mediator.Send(new GetAllUsersQuery { Type = (int)UserType.Doctor});
        //return View(doctors);
        return View();
    }
}
