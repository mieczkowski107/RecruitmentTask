using RecruitmentTask.Models;

namespace RecruitmentTask.Services.CatFactApi;

public class CatFactApi : ICatFactApi
{
    private readonly HttpClient _httpClient;
    private const string CatFactEndpoint = "factxx";

    public CatFactApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatFact> GetCatFact()
    {
        CatFact? catFact = null!;
        try
        {
            var response = await _httpClient.GetAsync(CatFactEndpoint);
            if(response.IsSuccessStatusCode)
            {
                catFact = await response.Content.ReadFromJsonAsync<CatFact>();
            }
        }
        catch (Exception ex) 
        {
            throw new CatApiException(ex);
        }
        if (catFact == null)
        {
            throw new CatApiException();
        }
        return catFact;
        
    }
}
