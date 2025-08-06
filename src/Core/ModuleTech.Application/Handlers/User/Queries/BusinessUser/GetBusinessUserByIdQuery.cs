using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.User.DTOs;


namespace ModuleTech.Application.Handlers.User.Queries.BusinessUser;

public class GetBusinessUserByIdQuery : IQuery<BusinessUserGetByIdDTO>
{
    public Guid Id { get; set; }
}

public sealed class GetBusinessUserByIdHandler : BaseQueryHandler<GetBusinessUserByIdQuery, BusinessUserGetByIdDTO>
{
    protected readonly IBusinessUserService _userService;

    public GetBusinessUserByIdHandler(IBusinessUserService userService)
    {
        _userService = userService;
    }
    public override async Task<BusinessUserGetByIdDTO> Handle(GetBusinessUserByIdQuery request, CancellationToken cancellationToken  )
    {
        return await _userService.GetByIdAsync(request.Id, cancellationToken);
    }
}
