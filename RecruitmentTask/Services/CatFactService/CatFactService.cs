using Microsoft.Extensions.Options;
using RecruitmentTask.Models;
using RecruitmentTask.Services.CatFactApi;
using RecruitmentTask.Services.FileHandler;
using System.Text.Json;


namespace RecruitmentTask.Services.CatFactService;

public class CatFactService : ICatFactService
{
    private readonly ICatFactApi _catFactApi;
    private readonly IFileHandler _fileHandler;
    private readonly FileSetting _fileSetting;
    public CatFactService(ICatFactApi apiHandler, IFileHandler fileHandler, IOptions<FileSetting> fileSetting)
    {
        _catFactApi = apiHandler;
        _fileHandler = fileHandler;
        _fileSetting = fileSetting.Value;
    }

    public async Task<CatFact?> FetchAndSave()
    {
        var catFact = await _catFactApi.GetCatFact();
        if (catFact != null)
        {
            var content = FormatCatFactForFile(catFact);
            var filePath = Path.Combine(_fileSetting.Path, _fileSetting.Name);
            await _fileHandler.AppendToFile(filePath, content);
            return catFact;
        }
        return null;
    }

    public async Task<FileDto> GetCatFile()
    {
        var filePath = Path.Combine(_fileSetting.Path, _fileSetting.Name);
        var FileDto = new FileDto
        {
            Data = await _fileHandler.GetFile(filePath)
        };
        return FileDto;
    }

    private string FormatCatFactForFile(CatFact catFact)
    {
        return JsonSerializer.Serialize(catFact) + "\n";
    }

}
