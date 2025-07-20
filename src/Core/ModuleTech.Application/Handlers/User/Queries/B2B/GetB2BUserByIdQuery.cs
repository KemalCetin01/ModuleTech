using ModuleTech.Core.Base.Handlers;
using ModuleTech.Application.Core.Infrastructure.Services;
using ModuleTech.Application.Handlers.User.DTOs;


namespace ModuleTech.Application.Handlers.User.Queries.B2B;

public class GetB2BUserByIdQuery : IQuery<B2BUserGetByIdDTO>
{
    public Guid Id { get; set; }
}

public sealed class GetB2BUserByIdHandler : BaseQueryHandler<GetB2BUserByIdQuery, B2BUserGetByIdDTO>
{
    protected readonly IUserB2BService _userService;

    public GetB2BUserByIdHandler(IUserB2BService userService)
    {
        _userService = userService;
    }
    public override async Task<B2BUserGetByIdDTO> Handle(GetB2BUserByIdQuery request, CancellationToken cancellationToken  )
    {
        return await _userService.GetByIdAsync(request.Id, cancellationToken);
    }
}
