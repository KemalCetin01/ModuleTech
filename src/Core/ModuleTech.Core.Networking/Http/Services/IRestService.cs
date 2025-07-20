using System.Text.Json;
using ModuleTech.Core.Networking.Http.Models;

namespace ModuleTech.Core.Networking.Http.Services;

public interface IRestService
{
    Task<RestDetailedResponse<TResponse, TErrorResponse>?> GetAsync<TResponse, TErrorResponse>(string endpoint,
        JsonSerializerOptions? jsonSerializerOptions = null,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse;

    Task<TResponse?> GetAsync<TResponse>(string endpoint,
        JsonSerializerOptions? jsonSerializerOptions = null,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse;

    Task<RestDetailedResponse<TResponse, TErrorResponse>?> GetAsync<TResponse, TErrorResponse>(string endpoint,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse;

    Task<TResponse?> GetAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse;


    Task<RestDetailedResponse<TResponse, TErrorResponse>?> UpdateAsync<TResponse, TRequest, TErrorResponse>(
        string endpoint, TRequest req,
        JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TRequest : IRestRequest
        where TErrorResponse : IRestErrorResponse;

    Task<TResponse?> UpdateAsync<TResponse, TRequest>(string endpoint, TRequest req,
        JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TRequest : IRestRequest;

    Task<RestDetailedResponse<TResponse, TErrorResponse>?> UpdateAsync<TResponse, TRequest, TErrorResponse>(
        string endpoint, TRequest req,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TRequest : IRestRequest
        where TErrorResponse : IRestErrorResponse;

    Task<TResponse?> UpdateAsync<TResponse, TRequest>(string endpoint, TRequest req,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TRequest : IRestRequest;

    Task<RestDetailedListResponse<TResponse, TErrorResponse>?> GetListAsync<TResponse, TErrorResponse>(string endpoint,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse;

    Task<RestDetailedListResponse<TResponse, TErrorResponse>?> GetListAsync<TResponse, TErrorResponse>(string endpoint,
        JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse;

    Task<List<TResponse>?> GetListAsync<TResponse>(string endpoint,
        JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse;

    Task<List<TResponse>?> GetListAsync<TResponse>(string endpoint,
        CancellationToken cancellationToken = default) where TResponse : IRestResponse;

    Task<RestDetailedResponse<TResponse, TErrorResponse>?> PostAsync<TResponse, TRequest, TErrorResponse>(
        string endpoint, TRequest req,
        JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TRequest : IRestRequest
        where TErrorResponse : IRestErrorResponse;

    Task<TResponse?> PostAsync<TResponse, TRequest>(string endpoint, TRequest req,
        JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TRequest : IRestRequest;

    Task<RestDetailedResponse<TResponse, TErrorResponse>?> PostAsync<TResponse, TRequest, TErrorResponse>(
        string endpoint, TRequest req,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TRequest : IRestRequest
        where TErrorResponse : IRestErrorResponse;

    Task<TResponse?> PostAsync<TResponse, TRequest>(string endpoint, TRequest req,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TRequest : IRestRequest;

    Task<RestDetailedResponse<TResponse, TErrorResponse>?> DeleteAsync<TResponse, TErrorResponse>(string endpoint,
        JsonSerializerOptions? jsonSerializerOptions = null,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse;

    Task<TResponse?> DeleteAsync<TResponse>(string endpoint, JsonSerializerOptions? jsonSerializerOptions = null,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse;

    Task<RestDetailedResponse<TResponse, TErrorResponse>?> DeleteAsync<TResponse, TErrorResponse>(string endpoint,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse;

    Task<TResponse?> DeleteAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse;

    Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken cancellationToken = default);
}