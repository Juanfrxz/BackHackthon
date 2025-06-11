namespace Domain.Entities;  
 public class Professional : BaseEntity 
 { 
       public int Id { get; set; }
       public Profession? ProfessionId { get; set; }
       public PersonProfile? ProfileId { get; set; }
 } 
