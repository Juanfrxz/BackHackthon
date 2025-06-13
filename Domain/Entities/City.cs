namespace Domain.Entities;
public class City : BaseEntity
{
       public int Id { get; set; }
       public string? Name { get; set; }
       public int RegionId { get; set; }
       public Region? Region { get; set; }
       public ICollection<PersonProfile>? PersonProfiles { get; set; }
}