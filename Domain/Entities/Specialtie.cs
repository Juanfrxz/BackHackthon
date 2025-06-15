namespace Domain.Entities;  
public class Specialtie : BaseEntity 
{
      public int ProfessionalId { get; set; }
      public Professional Professional { get; set; }
      public int SpecialtyId { get; set; }
      public Specialty Specialty { get; set; }
}