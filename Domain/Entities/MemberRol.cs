namespace Domain.Entities;  
public class MemberRol : BaseEntity 
{
      public int MemberId { get; set; }
      public Member? Member { get; set; }
      public int RolId { get; set; }
      public Rol? Rol { get; set; }
}