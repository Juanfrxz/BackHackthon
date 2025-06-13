namespace Domain.Entities;  
public class PersonType : BaseEntity 
{ 
       public int Id { get; set; } 
       public string? Description { get; set; }
       public ICollection<PersonProfile>? PersonProfiles { get; set; }
}