﻿using System.Text.Json;
using System.Text.Json.Nodes;

namespace Application.Helpers;

public static class JsonHelper
{
    /// <summary>
    /// Checks if the provided string is a valid JSON.
    /// </summary>
    /// <param name="input">The input string to check.</param>
    /// <returns>true if the input is valid JSON; otherwise, false.</returns>
    public static bool IsValidJson(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        input = input.Trim();

        if ((input.StartsWith("{") && input.EndsWith("}")) ||   // For objects
            (input.StartsWith("[") && input.EndsWith("]")))     // For array
        {
            try
            {
                var _ = JsonValue.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        return false;
    }

    /// <summary>
    /// Formats a JSON string to be more human-readable with indented formatting.
    /// </summary>
    /// <param name="input">The JSON string to prettify. If the string is null or empty, the method returns an empty string.</param>
    /// <returns>A prettified JSON string with indented formatting. If the input is null or empty, returns an empty string.</returns>
    public static string PrettifyJson(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }

        JsonElement jsonElement = JsonDocument.Parse(input).RootElement;

        return JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}
