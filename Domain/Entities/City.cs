namespace Domain.Entities;
public class City : BaseEntity
{
       public int Id { get; set; }
       public string? Name { get; set; }
       public Region? RegionId { get; set; }
}
