using System;
using System.ComponentModel.DataAnnotations;

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace TestApp.WebApp.Options;

public class JsonPlaceholderApiOptions
{
    public const string JsonPlaceholderApi = "JsonPlaceholderApi";

    [Required]
    public Uri BaseAddress { get; init; }
}
