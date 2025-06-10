namespace Domain.Entities;  
 public class Constituent : BaseEntity 
 { 
        public int SupportnetworkId { get; set; } 
        public int PersonprofileId { get; set; } 
        public string? MemberName { get; set; } 
        public string? Email { get; set; } 
        public int TypeRelationId { get; set; } 
        public int PriorityLevelId { get; set; } 
 } 
