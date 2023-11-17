using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
namespace WebApp.Models.ReqRes
{
    // ReSharper disable once UnusedType.Global
    public record CollectionResponse<T>
    {
        public int Page { get; init; }
        public int PerPage { get; init; }
        public int Total { get; init; }
        public int TotalPages { get; init; }
        public IEnumerable<T> Data { get; init; }
    }
}
