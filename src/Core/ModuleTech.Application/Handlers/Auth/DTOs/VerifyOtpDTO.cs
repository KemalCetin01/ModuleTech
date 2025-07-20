using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Auth.DTOs;

public class VerifyOtpDTO : IResponse
{
    public string OtpCode { get; set; }
    public Guid TransactionId { get; set; }
}