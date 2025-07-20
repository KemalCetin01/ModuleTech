namespace ModuleTech.Core.Networking.Http.Models;

public class RestDetailedListResponse<TResponse,TErrorResponse> 
    where TResponse : IRestResponse
    where TErrorResponse :  IRestErrorResponse
{
    public bool IsSuccessStatusCode { get; set; }
    public ICollection<TResponse>? Response { get; set; }
    public TErrorResponse? Error { get; set; }
}

