namespace RecruitmentTask;

public class CatApiException : Exception
{
    public CatApiException() : base("Failed to fetch CatFact") { }
    public CatApiException(Exception ex) : base("Failed to fetch CatFact") { }
}
