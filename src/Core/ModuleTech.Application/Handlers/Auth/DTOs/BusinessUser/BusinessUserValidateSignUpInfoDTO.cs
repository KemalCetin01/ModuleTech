using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Application.Handlers.Auth.DTOs.BusinessUser;

public class BusinessUserValidateSignUpInfoDTO : IResponse
{
    public string CompanyName { get; set; }
    public int SectorId { get; set; } 
    public int NumberOfEmployeeId { get; set; }
    public int ActivityAreaId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Suffix { get; set; }
    public int PositionId { get; set; }
    public int OccupationId { get; set; } //meslek

}