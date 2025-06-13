namespace Application.DTOs.Blog;

public class BlogDto
{
    public int Id { get; set; } 
    public string? Summary { get; set; } 
    public DateTime LogDate { get; set; }
    public string? Transcription { get; set; }
    public string? PerceptionAnalysis { get; set; }
    public int PersonProfileId { get; set; }
    public int RiskTypeId { get; set; }
}
