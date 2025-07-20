using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Auth.DTOs;

public class ResendOtpDTO : IResponse
{
    public Guid? TransactionId { get; set; }
    public string? OTPCode { get; set; }
}