using Microsoft.Extensions.Options;
using RecruitmentTask.Services.ApiHandler;
using RecruitmentTask.Services.ApiToFile;
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
        builder.Services.AddHttpClient<IApiHandler, ApiHandler>((httpClient) =>
        {
            httpClient.BaseAddress = new Uri("https://catfact.ninja");
        });

        builder.Services.AddScoped<IFileHandler, FileHandler>();
        builder.Services.AddScoped<IApiToFileService, ApiToFileService>();


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
