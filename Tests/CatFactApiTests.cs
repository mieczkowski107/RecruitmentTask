using RecruitmentTask;
using RecruitmentTask.Services.CatFactApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

public class CatFactApiTests
{
    private const string ValidEndpoint = "https://catfact.ninja";
    private const string InvalidEndpoint = "https://fact.ninja";

    [Fact]
    public async Task GetCatFact_EndpointIsValid_ShouldReturnCatFact()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri (ValidEndpoint);
        ICatFactApi catFactApi = new CatFactApi(client);      
        
        var result = await catFactApi.GetCatFact();

        Assert.False(string.IsNullOrWhiteSpace(result.Fact));
    }

    [Fact]
    public async Task GetCatFact_EndpointIsInvalid_ShouldThrowCatApiException()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(InvalidEndpoint);
        ICatFactApi catFactApi = new CatFactApi(client);

        await Assert.ThrowsAsync<CatApiException>(async () => await catFactApi.GetCatFact());
    }
}
