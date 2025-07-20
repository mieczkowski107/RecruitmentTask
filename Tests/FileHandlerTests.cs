using RecruitmentTask.Services.FileHandler;
using System.Text;

namespace Tests;

public class FileHandlerTests
{
    private string filePath = "test.txt";
    private const string textToAppend = "test";

    [Fact]
    public async Task AppendToFile_FileNotExisting_ShouldCreateAndAppendToFile()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        IFileHandler fileHandler = new FileHandler();

        await fileHandler.AppendToFile(filePath, textToAppend);
        var result = await fileHandler.GetFile(filePath);
        var content = Encoding.UTF8.GetString(result);

        Assert.Equal(textToAppend,content);

        
    }

    [Fact]
    public async Task AppendToFile_FileExisting_ShouldAppendToFile()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        IFileHandler fileHandler = new FileHandler();

        await fileHandler.AppendToFile(filePath, textToAppend);
        var firstAppend = await fileHandler.GetFile(filePath);

        await fileHandler.AppendToFile(filePath, textToAppend);
        var secondAppend= await fileHandler.GetFile(filePath);

        Assert.True(firstAppend.Length < secondAppend.Length);
    }
}
