using RecruitmentTask.Models;

namespace RecruitmentTask.Services.ApiHandler;

public interface IApiHandler
{
    Task<CatFact?> GetCatFact();
}
