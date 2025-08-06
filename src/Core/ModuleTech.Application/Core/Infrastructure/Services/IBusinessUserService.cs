using ModuleTech.Application.Handlers.User.DTOs;
using ModuleTech.Core.Base.IoC;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Infrastructure.Services;
public interface IBusinessUserService : IScopedService
{
    Task<PagedResponse<BusinessUserListDTO>> GetUsersAsync(SearchQueryModel<BusinessUserQueryServiceFilter> searchQuery, CancellationToken cancellationToken);
    Task<BusinessUserGetByIdDTO> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<BusinessUserGetByIdDTO> CreateAsync(CreateBusinessUserCommandDTO model, CancellationToken cancellationToken);
    Task<BusinessUserGetByIdDTO> UpdateAsync(UpdateBusinessUserCommandDTO b2BUserGetByIdDTO, CancellationToken cancellationToken);
    Task DeleteAsync(Guid Id, CancellationToken cancellationToken);
    Task<int> GetActiveUserInRoleCountAsync(Guid userGroupRoleId, CancellationToken cancellationToken);
    Task<bool> ResetPasswordAsync(ResetPasswordCommandDTO model, CancellationToken cancellationToken);
}

