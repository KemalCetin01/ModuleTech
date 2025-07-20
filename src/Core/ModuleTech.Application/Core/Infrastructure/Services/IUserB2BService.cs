using ModuleTech.Application.Handlers.User.DTOs;
using ModuleTech.Core.Base.IoC;
using ModuleTech.Core.Base.Models;
using ModuleTech.Core.Base.Wrapper;
using ModuleTech.Domain.EntityFilters;

namespace ModuleTech.Application.Core.Infrastructure.Services;
public interface IUserB2BService : IScopedService
{
    Task<PagedResponse<B2BUserListDTO>> GetUsersAsync(SearchQueryModel<UserB2BQueryServiceFilter> searchQuery, CancellationToken cancellationToken);
    Task<B2BUserGetByIdDTO> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task<B2BUserGetByIdDTO> CreateAsync(CreateB2BUserCommandDTO model, CancellationToken cancellationToken);
    Task<B2BUserGetByIdDTO> UpdateAsync(UpdateB2BUserCommandDTO b2BUserGetByIdDTO, CancellationToken cancellationToken);
    Task DeleteAsync(Guid Id, CancellationToken cancellationToken);
    Task<int> GetActiveUserInRoleCountAsync(Guid userGroupRoleId, CancellationToken cancellationToken);
    Task<bool> ResetPasswordAsync(ResetPasswordCommandDTO model, CancellationToken cancellationToken);
}

