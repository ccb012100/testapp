using System;

// ReSharper disable UnusedMember.Global

namespace WebApp.Api.Models.ReqRes
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public record User
    {
        public int Id { get; init; }
        public string Email { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Uri Avatar { get; init; }
    }
}
