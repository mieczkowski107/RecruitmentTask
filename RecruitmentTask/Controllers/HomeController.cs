using Microsoft.AspNetCore.Mvc;
using RecruitmentTask.Models;
using RecruitmentTask.Services.CatFactService;
using System.Diagnostics;

namespace RecruitmentTask.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICatFactService _catFactService;

    public HomeController(ILogger<HomeController> logger, ICatFactService apiToFileService)
    {
        _logger = logger;
        _catFactService = apiToFileService;
    }

    public async Task<IActionResult> Index()
    {
        var fetchedCatFact = await _catFactService.FetchAndSave();
        return View(fetchedCatFact);
    }

    public async Task<IActionResult> CatFactFileDownload()
    {
        var file = await _catFactService.GetCatFile();
        return File(file.Data, file.MimeType, file.Name);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
