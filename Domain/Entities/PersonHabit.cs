namespace Domain.Entities;  
 public class PersonHabit : BaseEntity 
 { 
        public int Id { get; set; } 
        public int PersonProfileId { get; set; } 
        public int HabitsId { get; set; } 
        public DateTime RegistrationDate { get; set; } 
 } 
