namespace Domain.Entities;  
public class TypeRelation : BaseEntity 
{ 
       public int Id { get; set; } 
       public string? Description { get; set; }
       public ICollection<Constituent>? Constituents { get; set; }
}