using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Options
{
    public class ReqResApiOptions
    {
        public const string ReqResApi = "ReqResApi";

        [Required]
        public Uri BaseAddress { get; init; }
    }
}
