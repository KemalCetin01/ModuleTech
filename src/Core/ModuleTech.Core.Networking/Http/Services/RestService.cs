using System.Text;
using System.Text.Json;
using ModuleTech.Core.Networking.Http.Models;

namespace ModuleTech.Core.Networking.Http.Services;

public abstract class RestService : HttpService, IRestService
{
    protected RestService(HttpClient client, string? baseAddress = null,
        Dictionary<string, string>? requestHeaders = null)
        : base(client, baseAddress, requestHeaders)
    {
    }

    public async Task<RestDetailedResponse<TResponse, TErrorResponse>?> GetAsync<TResponse, TErrorResponse>(
        string endpoint,
        JsonSerializerOptions? jsonSerializerOptions = null,
        CancellationToken cancellationToken = default) where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse
    {
        var response = await Client.GetAsync(endpoint, cancellationToken);
        return await ContentToTResponse<TResponse, TErrorResponse>(response, jsonSerializerOptions);
    }

    public async Task<TResponse?> GetAsync<TResponse>(string endpoint,
        JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
    {
        var response = await Client.GetAsync(endpoint, cancellationToken);
        return await ContentToTResponse<TResponse>(response, jsonSerializerOptions);
    }

    public async Task<RestDetailedResponse<TResponse, TErrorResponse>?> GetAsync<TResponse, TErrorResponse>(
        string endpoint,
        CancellationToken cancellationToken = default) where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse
    {
        return await GetAsync<TResponse, TErrorResponse>(endpoint, null, cancellationToken);
    }

    public async Task<TResponse?> GetAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
    {
        return await GetAsync<TResponse>(endpoint, null, cancellationToken);
    }

    public async Task<RestDetailedResponse<TResponse, TErrorResponse>?>
        UpdateAsync<TResponse, TRequest, TErrorResponse>(string endpoint, TRequest req,
            JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse where TRequest : IRestRequest where TErrorResponse : IRestErrorResponse
    {
        var stringContent = new StringContent(JsonSerializer.Serialize(req), Encoding.UTF8,
            Client.DefaultRequestHeaders.Accept.ToString());
        var response = await Client.PutAsync(endpoint, stringContent, cancellationToken);
        return await ContentToTResponse<TResponse, TErrorResponse>(response, jsonSerializerOptions);
    }

    public async Task<RestDetailedListResponse<TResponse, TErrorResponse>?> GetListAsync<TResponse, TErrorResponse>(
        string endpoint, JsonSerializerOptions? jsonSerializerOptions = null,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse
    {
        var response = await Client.GetAsync(endpoint, cancellationToken);
        return await ContentToTResponseList<TResponse, TErrorResponse>(response, jsonSerializerOptions);
    }

    public async Task<List<TResponse>?> GetListAsync<TResponse>(string endpoint,
        JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
    {
        var response = await Client.GetAsync(endpoint, cancellationToken);
        return await ContentToTResponseList<TResponse>(response, jsonSerializerOptions);
    }

    public async Task<List<TResponse>?> GetListAsync<TResponse>(string endpoint,
        CancellationToken cancellationToken = default) where TResponse : IRestResponse
    {
        return await GetListAsync<TResponse>(endpoint, null, cancellationToken);
    }

    public async Task<TResponse?> UpdateAsync<TResponse, TRequest>(string endpoint, TRequest req,
        JsonSerializerOptions? jsonSerializerOptions = null,
        CancellationToken cancellationToken = default) where TResponse : IRestResponse where TRequest : IRestRequest
    {
        var stringContent = new StringContent(JsonSerializer.Serialize(req), Encoding.UTF8,
            Client.DefaultRequestHeaders.Accept.ToString());
        var response = await Client.PutAsync(endpoint, stringContent, cancellationToken);
        return await ContentToTResponse<TResponse>(response, jsonSerializerOptions);
    }

    public async Task<RestDetailedResponse<TResponse, TErrorResponse>?>
        UpdateAsync<TResponse, TRequest, TErrorResponse>(string endpoint, TRequest req,
            CancellationToken cancellationToken = default) where TResponse : IRestResponse
        where TRequest : IRestRequest
        where TErrorResponse : IRestErrorResponse
    {
        return await UpdateAsync<TResponse, TRequest, TErrorResponse>(endpoint, req, null, cancellationToken);
    }

    public async Task<TResponse?> UpdateAsync<TResponse, TRequest>(string endpoint, TRequest req,
        CancellationToken cancellationToken = default) where TResponse : IRestResponse where TRequest : IRestRequest
    {
        return await UpdateAsync<TResponse, TRequest>(endpoint, req, null, cancellationToken);
    }

    public async Task<RestDetailedListResponse<TResponse, TErrorResponse>?> GetListAsync<TResponse, TErrorResponse>(
        string endpoint, CancellationToken cancellationToken = default) where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse
    {
        return await GetListAsync<TResponse, TErrorResponse>(endpoint, null, cancellationToken);
    }

    public async Task<RestDetailedResponse<TResponse, TErrorResponse>?> PostAsync<TResponse, TRequest, TErrorResponse>(
        string endpoint, TRequest req,
        JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse where TRequest : IRestRequest where TErrorResponse : IRestErrorResponse
    {
        var stringContent = new StringContent(JsonSerializer.Serialize(req), Encoding.UTF8,
            Client.DefaultRequestHeaders.Accept.ToString());
        var response = await Client.PostAsync(endpoint, stringContent, cancellationToken);
        return await ContentToTResponse<TResponse, TErrorResponse>(response, jsonSerializerOptions);
    }

    public async Task<TResponse?> PostAsync<TResponse, TRequest>(string endpoint, TRequest req,
        JsonSerializerOptions? jsonSerializerOptions = null,
        CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
        where TRequest : IRestRequest
    {
        var stringContent = new StringContent(JsonSerializer.Serialize(req), Encoding.UTF8,
            Client.DefaultRequestHeaders.Accept.ToString());
        var response = await Client.PostAsync(endpoint, stringContent, cancellationToken);
        return await ContentToTResponse<TResponse>(response, jsonSerializerOptions);
    }

    public async Task<RestDetailedResponse<TResponse, TErrorResponse>?> PostAsync<TResponse, TRequest, TErrorResponse>(
        string endpoint, TRequest req,
        CancellationToken cancellationToken = default) where TResponse : IRestResponse
        where TRequest : IRestRequest
        where TErrorResponse : IRestErrorResponse
    {
        return await PostAsync<TResponse, TRequest, TErrorResponse>(endpoint, req, null, cancellationToken);
    }

    public async Task<TResponse?> PostAsync<TResponse, TRequest>(string endpoint, TRequest req,
        CancellationToken cancellationToken = default) where TResponse : IRestResponse where TRequest : IRestRequest
    {
        return await PostAsync<TResponse, TRequest>(endpoint, req, null, cancellationToken);
    }

    public async Task<RestDetailedResponse<TResponse, TErrorResponse>?> DeleteAsync<TResponse, TErrorResponse>(
        string endpoint,
        JsonSerializerOptions? jsonSerializerOptions = null,
        CancellationToken cancellationToken = default) where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse
    {
        var response = await Client.DeleteAsync(endpoint, cancellationToken);
        return await ContentToTResponse<TResponse, TErrorResponse>(response, jsonSerializerOptions);
    }

    public async Task<TResponse?> DeleteAsync<TResponse>(string endpoint,
        JsonSerializerOptions? jsonSerializerOptions = null, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
    {
        var response = await Client.DeleteAsync(endpoint, cancellationToken);
        return await ContentToTResponse<TResponse>(response, jsonSerializerOptions);
    }

    public async Task<RestDetailedResponse<TResponse, TErrorResponse>?> DeleteAsync<TResponse, TErrorResponse>(
        string endpoint,
        CancellationToken cancellationToken = default) where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse
    {
        return await DeleteAsync<TResponse, TErrorResponse>(endpoint, null, cancellationToken);
    }

    public async Task<TResponse?> DeleteAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default)
        where TResponse : IRestResponse
    {
        return await DeleteAsync<TResponse>(endpoint, null, cancellationToken);
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage req,
        CancellationToken cancellationToken = default)
    {
        return await Client.SendAsync(req, cancellationToken);
    }

    private async Task<TResponse?> ContentToTResponse<TResponse>(HttpResponseMessage httpResponse,
        JsonSerializerOptions? jsonSerializerOptions = null) where TResponse : IRestResponse
    {
        if (httpResponse == null)
            throw new HttpRequestException("Response is null");
        if (httpResponse.IsSuccessStatusCode)
        {
            var result = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(result, jsonSerializerOptions);
        }

        throw new Exception($"Connected remote server has a error. Status code is {httpResponse.StatusCode}");
    }

    private async Task<RestDetailedResponse<TResponse, TErrorResponse>?> ContentToTResponse<TResponse, TErrorResponse>(
        HttpResponseMessage httpResponse,
        JsonSerializerOptions? jsonSerializerOptions = null)
        where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse
    {
        if (httpResponse == null)
            throw new HttpRequestException("Response is null");
        var result = await httpResponse.Content.ReadAsStringAsync();
        var response = new RestDetailedResponse<TResponse, TErrorResponse>
        {
            IsSuccessStatusCode = false
        };
        if (httpResponse.IsSuccessStatusCode)
        {
            var tResponse = JsonSerializer.Deserialize<TResponse>(result, jsonSerializerOptions);
            response.IsSuccessStatusCode = true;
            response.Response = tResponse;
            return response;
        }

        var tErrorResponse = JsonSerializer.Deserialize<TErrorResponse>(result, jsonSerializerOptions);
        response.Error = tErrorResponse;
        return response;
    }

    private async Task<List<TResponse>?> ContentToTResponseList<TResponse>(HttpResponseMessage httpResponse,
        JsonSerializerOptions? jsonSerializerOptions = null)
    {
        if (httpResponse == null)
            throw new HttpRequestException("Response is null");
        if (httpResponse.IsSuccessStatusCode)
        {
            var result = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<TResponse>>(result, jsonSerializerOptions);
        }

        throw new Exception($"Connected remote server has a error. Status code is {httpResponse.StatusCode}");
    }

    private async Task<RestDetailedListResponse<TResponse, TErrorResponse>?> ContentToTResponseList<TResponse,
        TErrorResponse>(HttpResponseMessage httpResponse,
        JsonSerializerOptions? jsonSerializerOptions = null)
        where TResponse : IRestResponse
        where TErrorResponse : IRestErrorResponse
    {
        if (httpResponse == null)
            throw new HttpRequestException("Response is null");

        var result = await httpResponse.Content.ReadAsStringAsync();

        var response = new RestDetailedListResponse<TResponse, TErrorResponse>
        {
            IsSuccessStatusCode = false
        };
        if (httpResponse.IsSuccessStatusCode)
        {
            var tResponse = JsonSerializer.Deserialize<ICollection<TResponse>>(result, jsonSerializerOptions);
            response.IsSuccessStatusCode = true;
            response.Response = tResponse;
            return response;
        }

        var tErrorResponse = JsonSerializer.Deserialize<TErrorResponse>(result, jsonSerializerOptions);
        response.Error = tErrorResponse;
        return response;
    }
}