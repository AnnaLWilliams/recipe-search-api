using System.Text.Json.Serialization;

namespace RecipeApi.Dto;

public class ErrorResponce
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("errors")]
    public string[]? Errors { get; set; }
}