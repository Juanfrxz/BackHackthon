namespace Domain.Entities;  
public class Member : BaseEntity 
{ 
      public int Id { get; set; } 
      public string? Username { get; set; } 
      public string? Email { get; set; } 
      public string? Password { get; set; }
      public ICollection<MemberRol>? MemberRols { get; set; }
      public ICollection<PersonProfile>? PersonProfiles { get; set; }
      public ICollection<RefreshToken>? RefreshTokens { get; set; }
}