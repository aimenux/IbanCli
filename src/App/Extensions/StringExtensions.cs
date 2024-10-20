using System.Text.Json;
using System.Text.RegularExpressions;

namespace App.Extensions;

public static partial class StringExtensions
{
    private const int MatchTimeoutMilliseconds = 1000;
    
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true
    };
    
    public static string FormatJson(this string json)
    {
        using var document = JsonDocument.Parse(json);
        return JsonSerializer.Serialize(document, Options);
    }
    
    public static string RemoveWhitespaces(this string value)
    {
        return RemoveWhitespacesRegex().Replace(value, string.Empty);
    }
    
    [GeneratedRegex(@"\s+", RegexOptions.Compiled, MatchTimeoutMilliseconds)]
    private static partial Regex RemoveWhitespacesRegex();
}