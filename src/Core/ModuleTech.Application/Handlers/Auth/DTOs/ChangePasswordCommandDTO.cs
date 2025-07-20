using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Auth.DTOs;

public class ChangePasswordCommandDTO : IResponse
{
    public Guid TransactionId { get; set; }
    public string Password { get; set; }
}
