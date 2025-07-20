using Microsoft.AspNetCore.Mvc;

namespace ModuleTech.Core.Base.Dtos;

public class HeaderContext
{
    [FromHeader(Name = "ODRefId")] public Guid? ODRefId { get; set; }

    [FromHeader(Name = "Locale")] public string Locale { get; set; } = "tr-TR";
}