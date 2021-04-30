// ReSharper disable UnusedMember.Global

namespace WebApp.Api.Models.JsonPlaceholder
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record Post
    {
        public int Id { get; init; }
        public int UserId { get; init; }
        public string Body { get; init; }
        public string Title { get; init; }
    }
}
