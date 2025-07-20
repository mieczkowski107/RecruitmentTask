using RecruitmentTask.Models;

namespace RecruitmentTask.Services.ApiHandler;

public class ApiHandler : IApiHandler
{
    private readonly HttpClient _httpClient;
    private const string CatFactEndpoint = "fact";

    public ApiHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatFact?> GetCatFact()
    {
        var content = await _httpClient.GetFromJsonAsync<CatFact>(CatFactEndpoint);
        return content;
    }
}
