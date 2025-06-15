namespace Domain.Entities;  
public class PhonePerson : BaseEntity 
{ 
      public int Id { get; set; } 
      public string PhoneNumber { get; set; }
      public int ContactTypeId { get; set; }
      public ContactType ContactType { get; set; } 
      public int PersonProfileId { get; set; }
      public PersonProfile PersonProfile { get; set; }
}