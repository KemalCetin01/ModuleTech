namespace ModuleTech.Core.Networking.Http.Services;

public abstract class HttpService : IHttpService
{
    protected readonly HttpClient Client;

    protected HttpService(HttpClient client, string? baseAddress = null,
        Dictionary<string, string>? requestHeaders = null)
    {
        Client = client ?? throw new ArgumentNullException(nameof(client));
        BaseAddress = baseAddress;
        if (requestHeaders != null)
            SetRequestHeaders(requestHeaders);
    }

    public string? BaseAddress
    {
        get => Client.BaseAddress?.ToString();
        set
        {
            if (value != null && Uri.CheckSchemeName(new Uri(value).Scheme))
                Client.BaseAddress = new Uri(value);
        }
    }

    public void SetRequestHeaders(Dictionary<string, string> headers)
    {
        foreach (var header in headers)
            Client.DefaultRequestHeaders.Add(header.Key, header.Value);
    }
}