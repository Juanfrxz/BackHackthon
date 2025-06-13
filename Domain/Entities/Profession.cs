namespace Domain.Entities;  
public class Profession : BaseEntity 
{ 
       public int Id { get; set; } 
       public string? Description { get; set; }
       public ICollection<Professional>? Professionals { get; set; }
}