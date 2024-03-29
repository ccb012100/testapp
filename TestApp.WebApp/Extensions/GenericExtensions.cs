using Newtonsoft.Json;

namespace TestApp.WebApp.Extensions;

public static class GenericExtensions
{
    public static string ToPrettyPrintJson<T>(this T t) =>
        JsonConvert.SerializeObject(t, Formatting.Indented);
}
