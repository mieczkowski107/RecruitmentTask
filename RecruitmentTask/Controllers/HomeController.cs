using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RecruitmentTask.Models;
using RecruitmentTask.Services.ApiToFile;

namespace RecruitmentTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiToFileService _apiToFileService;
        private readonly FileSetting _fileSetting;
       
        public HomeController(ILogger<HomeController> logger, IApiToFileService apiToFileService, IOptions<FileSetting> fileSetting)
        {
            _logger = logger;
            _apiToFileService = apiToFileService;
            _fileSetting = fileSetting.Value;
            
        }

        public async Task<IActionResult> Index()
        {
            var fetchedCatFact = await _apiToFileService.FetchAndSave();
            return View(fetchedCatFact);
        }

        public IActionResult CatFactFileDownload()
        {
            var filepath = Path.Combine(_fileSetting.Path, _fileSetting.Name);
            return File(System.IO.File.ReadAllBytes(filepath),"text/plain", _fileSetting.Name.ToLower());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
