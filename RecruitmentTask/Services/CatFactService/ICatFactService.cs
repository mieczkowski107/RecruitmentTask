using RecruitmentTask.Models;

namespace RecruitmentTask.Services.CatFactService;

public interface ICatFactService
{
    Task<CatFact?> FetchAndSave();
    Task<FileDto> GetCatFile();
}
