using Domain.Entities.Auth;

namespace Domain.Entities;  
public class PersonProfile : BaseEntity 
{ 
       public int Id { get; set; } 
       public string? Name { get; set; } 
       public string? LastName { get; set; }
       public int CityId { get; set; }
       public City? City { get; set; }
       public int PersonTypeId { get; set; }
       public PersonType? PersonType { get; set; }
       public int MemberId { get; set; }
       public UserMember? UserMember { get; set; }
       public ICollection<Blog>? Blogs { get; set; }
       public ICollection<PersonHabit>? PersonHabits { get; set; }
       public ICollection<Constituent>? Constituents { get; set; }
       public ICollection<Professional>? Professionals { get; set; }
       public ICollection<PhonePerson>? PhonePersons { get; set; }
}