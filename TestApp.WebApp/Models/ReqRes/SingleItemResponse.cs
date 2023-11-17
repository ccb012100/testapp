// ReSharper disable UnusedMember.Global

namespace TestApp.WebApp.Models.ReqRes;

// ReSharper disable once ClassNeverInstantiated.Global
public record SingleItemResponse<T>
{
    public T Data { get; init; }
}
