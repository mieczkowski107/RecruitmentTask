using RecruitmentTask.Services.CatFactApi;
using RecruitmentTask.Services.CatFactService;
using RecruitmentTask.Services.FileHandler;

namespace RecruitmentTask;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();


        builder.Services.Configure<FileSetting>(builder.Configuration.GetSection("FileSetting"));
        builder.Services.AddHttpClient<ICatFactApi, CatFactApi>((httpClient) =>
        {
            httpClient.BaseAddress = new Uri("https://catfact.ninja");
        });

        builder.Services.AddScoped<IFileHandler, FileHandler>();
        builder.Services.AddScoped<ICatFactService, CatFactService>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
