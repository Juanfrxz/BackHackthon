namespace Domain.Entities;  
 public class PhonePerson : BaseEntity 
 { 
        public int Id { get; set; } 
        public string? PhoneNumber { get; set; } 
        public int ContactTypeId { get; set; } 
        public int PersonalProfileId { get; set; } 
 } 
