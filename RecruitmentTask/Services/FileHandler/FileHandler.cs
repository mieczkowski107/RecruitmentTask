namespace RecruitmentTask.Services.FileHandler;

public class FileHandler : IFileHandler
{

    public async Task AppendToFile(string filePath, string content)
    {
        if (!string.IsNullOrWhiteSpace(filePath))
        {
            var directoryPath = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrWhiteSpace(directoryPath) && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            await File.AppendAllTextAsync(filePath, content);
        }

    }

    public async Task<byte[]> GetFile(string filePath)
    {
        return await File.ReadAllBytesAsync(filePath);
    }


}
