namespace Domain.Entities;  
 public class PersonHabit : BaseEntity 
 { 
        public int Id { get; set; } 
        public DateTime RegistrationDate { get; set; } 
        public PersonProfile? PersonProfileId { get; set; }
        public Habit? HabitsId { get; set; }
 } 
