namespace Domain.Entities;  
public class Professional : BaseEntity 
{ 
     public int Id { get; set; }
     public int ProfessionId { get; set; }
     public Profession? Profession { get; set; }
     public int PersonProfileId { get; set; }
     public PersonProfile? PersonProfile { get; set; }
     public ICollection<Specialtie>? Specialties { get; set; }
}