using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Auth.DTOs;

public class ResetVerifyOtpDTO : IResponse
{
    public Guid TransactionId { get; set; }
}