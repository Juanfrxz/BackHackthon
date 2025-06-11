namespace Domain.Entities;  
 public class Constituent : BaseEntity 
 { 
        public SupportNetwork? SupportnetworkId { get; set; } 
        public PersonProfile? PersonprofileId { get; set; } 
        public string? MemberName { get; set; } 
        public string? Email { get; set; } 
        public TypeRelation? TypeRelationId { get; set; } 
        public PriorityLevel? PriorityLevelId { get; set; } 
 } 
