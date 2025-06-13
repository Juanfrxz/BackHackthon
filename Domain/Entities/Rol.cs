namespace Domain.Entities;  
public class Rol : BaseEntity 
{ 
       public int Id { get; set; } 
       public string? Name { get; set; } 
       public string? Description { get; set; }
       public ICollection<MemberRol>? MemberRols { get; set; }
}