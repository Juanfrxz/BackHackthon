namespace Domain.Entities;  
 public class PhonePerson : BaseEntity 
 { 
        public int Id { get; set; } 
        public string? PhoneNumber { get; set; } 
        public ContactType? ContactTypeId { get; set; } 
        public PersonProfile? PersonalProfileId { get; set; } 
 } 
