namespace Domain.Entities;  
 public class EmotionalBlog : BaseEntity 
 { 
        public int Id { get; set; } 
        public string? Transcript { get; set; } 
        public string? PerceptionAnalysis { get; set; } 
        public DateTime LogDate { get; set; } 
        public int PersonProfile { get; set; } 
        public int RiskTypeId { get; set; } 
        public int EmotionalTypeId { get; set; } 
 } 
