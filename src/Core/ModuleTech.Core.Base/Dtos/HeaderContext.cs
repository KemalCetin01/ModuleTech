using Microsoft.AspNetCore.Mvc;

namespace ModuleTech.Core.Base.Dtos;

public class HeaderContext
{
    [FromHeader(Name = "IdentityRefId")] public Guid? IdentityRefId { get; set; }

    [FromHeader(Name = "Locale")] public string Locale { get; set; } = "tr-TR";
}