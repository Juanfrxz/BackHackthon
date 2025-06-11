namespace Domain.Entities;  
 public class EmotionalBlog : BaseEntity 
 { 
        public int Id { get; set; } 
        public string? Summary { get; set; } 
        public DateTime LogDate { get; set; } 
        public PersonProfile? PersonProfileId { get; set; }
        public RiskType? RiskTypeId { get; set; }
        public EmotionalType? EmotionalTypeId { get; set; }
 } 
