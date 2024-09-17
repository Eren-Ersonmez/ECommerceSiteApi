using Newtonsoft.Json;

namespace ECommerceSiteApi.Application.DTOs.FacebookDtos;

public class FacebookTokenValidationResponse
{
    public FacebookValidationToken Data { get; set; }
}
public class FacebookValidationToken
{
    [JsonProperty("is_valid")]
    public bool IsValid { get; set; }

    [JsonProperty("user_id")]
    public string UserId { get; set; }
}