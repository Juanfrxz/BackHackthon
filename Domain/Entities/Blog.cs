namespace Domain.Entities;  
public class Blog : BaseEntity 
{
    public int Id { get; set; } 
    public string? Summary { get; set; } 
    public DateTime LogDate { get; set; }
    public string? Transcription { get; set; }
    public string? PerceptionAnalysis { get; set; }
    public int PersonProfileId { get; set; }
    public PersonProfile? PersonProfile { get; set; }
    public int RiskTypeId { get; set; }
    public RiskType? RiskType { get; set; }
    public ICollection<EmotionalBlog>? EmotionalBlogs { get; set; }
}