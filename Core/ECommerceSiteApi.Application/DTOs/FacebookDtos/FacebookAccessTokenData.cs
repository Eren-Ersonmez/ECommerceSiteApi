

using Newtonsoft.Json;

namespace ECommerceSiteApi.Application.DTOs.FacebookDtos;

public class FacebookAccessTokenData
{

    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }
}
