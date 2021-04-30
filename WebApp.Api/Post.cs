// ReSharper disable UnusedMember.Global
namespace WebApp.Api
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
    }
}
