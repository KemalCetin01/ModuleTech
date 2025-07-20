using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using ModuleTech.Core.Base.Dtos;

namespace ModuleTech.Core.Base.Handlers;

public interface IRequestBus
{
    public Task<TResponse> Send<TResponse>(IRequest<TResponse> command, CancellationToken token = default)
        where TResponse : IResponse;

    public Task Send(IRequest command, CancellationToken token = default);
}