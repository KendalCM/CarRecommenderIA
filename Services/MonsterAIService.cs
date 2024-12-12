using Newtonsoft.Json;
using System.Text;

namespace CarRecommenderIA.Services;

public class MonsterAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl;

    public MonsterAIService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["MonsterAI:ApiKey"];
        _baseUrl = configuration["MonsterAI:BaseUrl"];
    }

    public async Task<string> GetCarRecommendations(string prompt)
    {
        var requestBody = new
        {
            prompt = prompt,
            maxTokens = 200
        };

        var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/v1/recommendations")
        {
            Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json")
        };

        request.Headers.Add("Authorization", $"Bearer {_apiKey}");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<dynamic>(responseBody);
        return result.generated_text.ToString();
    }
}
