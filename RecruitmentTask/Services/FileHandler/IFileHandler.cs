namespace RecruitmentTask.Services.FileHandler;

public interface IFileHandler
{
    Task AppendToFile(string filePath, string content);
    Task<byte[]> GetFile(string filePath);
}
