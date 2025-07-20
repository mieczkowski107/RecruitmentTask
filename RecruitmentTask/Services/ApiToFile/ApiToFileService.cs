using Microsoft.Extensions.Options;
using RecruitmentTask.Models;
using RecruitmentTask.Services.ApiHandler;
using RecruitmentTask.Services.FileHandler;


namespace RecruitmentTask.Services.ApiToFile;

public class ApiToFileService : IApiToFileService
{
    private readonly IApiHandler _apiHandler;
    private readonly IFileHandler _fileHandler;
    private readonly FileSetting _fileSetting;
    public ApiToFileService(IApiHandler apiHandler, IFileHandler fileHandler, IOptions<FileSetting> fileSetting)
    {
        _apiHandler = apiHandler;
        _fileHandler = fileHandler;
        _fileSetting = fileSetting.Value;
    }

    public async Task<CatFact?> FetchAndSave()
    {
        var catFact = await _apiHandler.GetCatFact();   
        if (catFact != null)
        {
            var content = FormatCatFactForFile(catFact);
            var filePath = Path.Combine(_fileSetting.Path, _fileSetting.Name);
            await _fileHandler.AppendToFile(filePath, content);
            return catFact;
        }
        return null;
    }

    private string FormatCatFactForFile(CatFact catFact)
    {
        return $"{catFact.Fact};{catFact.Length}\n";
    }
}
