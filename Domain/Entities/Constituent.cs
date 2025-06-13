namespace Domain.Entities;  
public class Constituent : BaseEntity 
{
       public string? MemberName { get; set; } 
       public string? Email { get; set; } 
       public int PersonprofileId { get; set; }
       public PersonProfile? Personprofile { get; set; } 
       public int SupportnetworkId { get; set; }
       public SupportNetwork? Supportnetwork { get; set; }
       public int PriorityLevelId { get; set; }
       public PriorityLevel? PriorityLevel { get; set; } 
       public int? TypeRelationId { get; set; }
       public TypeRelation? TypeRelation { get; set; } 
}