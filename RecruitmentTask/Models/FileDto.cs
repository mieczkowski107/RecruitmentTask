namespace RecruitmentTask.Models;

public class FileDto
{
    public string Name { get; set; } = "result.txt";
    public required byte[] Data { get; set; }
    public string MimeType { get; set; } = "text/plain";
}
