namespace Domain.Entities;  
public class EmotionalCategory : BaseEntity 
{ 
       public int Id { get; set; } 
       public string? Description { get; set; }
       public ICollection<EmotionalType>? EmotionalTypes { get; set; }
}