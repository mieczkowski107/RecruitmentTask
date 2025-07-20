using RecruitmentTask.Models;

namespace RecruitmentTask.Services.CatFactApi;

public interface ICatFactApi
{
    Task<CatFact> GetCatFact();
}
