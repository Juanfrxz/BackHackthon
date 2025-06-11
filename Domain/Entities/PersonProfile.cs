namespace Domain.Entities;  
 public class PersonProfile : BaseEntity 
 { 
        public int Id { get; set; } 
        public string? Name { get; set; } 
        public string? LastName { get; set; } 
        public City? CityId { get; set; }
        public PersonType? PersonTypeId { get; set; }
        public Member? MemberId { get; set; }
 } 
