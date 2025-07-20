﻿using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.UserEmployees.DTOs;

public class CreateUserEmployeeCommandDTO : IResponse
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public Guid RoleId { get; set; }
    public Guid IdentityRefId { get; set; }
}
