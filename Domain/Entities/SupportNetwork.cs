namespace Domain.Entities;  
public class SupportNetwork : BaseEntity 
{ 
       public int Id { get; set; } 
       public string Name { get; set; }
       public ICollection<Constituent> Constituents { get; set; }
}