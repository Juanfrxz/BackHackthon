namespace Domain.Entities;  
 public class ContactType : BaseEntity 
 { 
       public int Id { get; set; } 
       public string Description { get; set; }
       public ICollection<PhonePerson> PhonePersons { get; set; }
 }