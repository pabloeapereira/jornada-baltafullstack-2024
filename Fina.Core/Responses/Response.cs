using System.Text.Json.Serialization;

namespace Fina.Core.Responses;

public class Response<TData>
{
    private int _code = Configuration.DEFAULT_STATUS_CODE;

    [JsonConstructor]
    public Response() => _code = Configuration.DEFAULT_STATUS_CODE;
    public Response(TData? data,int code = Configuration.DEFAULT_STATUS_CODE, string? message = null)
    {
        _code = code;
        Data = data;
        Message = message;
    }

    public TData? Data { get; set; }
    public string? Message { get; set; }
    [JsonIgnore]
    public bool IsSuccess => _code >= 200 && _code <= 299;
}