namespace ModuleTech.Core.Networking.Http.Models;

public class RestDetailedResponse<TResponse,TErrorResponse> 
    where TResponse : IRestResponse 
    where TErrorResponse :  IRestErrorResponse
{
    public bool IsSuccessStatusCode { get; set; }
    public TResponse? Response { get; set; }
    public TErrorResponse? Error { get; set; }
}

