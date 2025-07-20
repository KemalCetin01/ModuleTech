﻿namespace ModuleTech.Application.DTOs.Identity.Request;
public class UpdateIdentityUserRequestDto
{
    public Guid IdentityRefId { get; set; }
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}