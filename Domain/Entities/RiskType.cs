namespace Domain.Entities;  
public class RiskType : BaseEntity 
{ 
       public int Id { get; set; } 
       public string Description { get; set; }
       public ICollection<Blog> Blogs { get; set; }
}