namespace Domain.Entities;  
public class Habit : BaseEntity 
{ 
       public int Id { get; set; } 
       public string? Description { get; set; }
       public ICollection<PersonHabit>? PersonHabits { get; set; }
}