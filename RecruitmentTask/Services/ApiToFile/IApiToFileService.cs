using RecruitmentTask.Models;

namespace RecruitmentTask.Services.ApiToFile;

public interface IApiToFileService
{
    Task<CatFact?> FetchAndSave();
}
