using System.Text.Json.Serialization;
namespace apitest.DTO;

public class UserResponceDTO
{
   [JsonPropertyName("data")]
    public UsersDataDTO Data { get; set; }
}