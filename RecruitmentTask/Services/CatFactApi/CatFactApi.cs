using RecruitmentTask.Models;

namespace RecruitmentTask.Services.CatFactApi;

public class CatFactApi : ICatFactApi
{
    private readonly HttpClient _httpClient;
    private const string CatFactEndpoint = "fact";

    public CatFactApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatFact?> GetCatFact()
    {
        var content = await _httpClient.GetFromJsonAsync<CatFact>(CatFactEndpoint);
        return content;
    }
}
