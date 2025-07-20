using ModuleTech.Core.Base.Dtos;
using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Handlers.Auth.DTOs;

public class SignUpDTO : IResponse
{
    public Guid? TransactionId { get; set; }
    public string? OTPCode { get; set; }
    public AuthenticationDTO authenticationDTO { get; set; }
}