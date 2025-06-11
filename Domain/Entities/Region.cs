namespace Domain.Entities;  
 public class Region : BaseEntity 
 { 
        public int Id { get; set; } 
        public string? Name { get; set; } 
        public Country? CountryId { get; set; }
 } 
