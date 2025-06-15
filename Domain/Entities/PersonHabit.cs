namespace Domain.Entities;  
public class PersonHabit : BaseEntity 
{ 
       public int Id { get; set; } 
       public DateTime RegistrationDate { get; set; }
       public int PersonProfileId { get; set; }
       public PersonProfile PersonProfile { get; set; }
       public int HabitId { get; set; }
       public Habit Habit { get; set; }
}