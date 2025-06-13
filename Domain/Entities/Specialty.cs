namespace Domain.Entities;  
public class Specialty : BaseEntity 
{ 
       public int Id { get; set; } 
       public string? Description { get; set; } 
       public ICollection<Specialtie>? Specialties { get; set; }
}