namespace ModuleTech.Core.Networking.Http.Infrastructure;

public class HttpServiceMiddleware : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await base.SendAsync(request, cancellationToken);
            response.EnsureSuccessStatusCode();
            return response;
        }
        catch (Exception)
        {
            //Logging
            throw new Exception("An exception occurred while processing the request");
            //throw new HttpServiceException("An exception occurred while processing the request");
        }
    }

    protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken) =>
        SendAsync(request, cancellationToken).Result;
}