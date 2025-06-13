using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Auth
{
    public class UserMember : BaseEntity 
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<UserMemberRoles>? MemberRols { get; set; }
        public ICollection<PersonProfile>? PersonProfiles { get; set; }
        public ICollection<RefreshToken>? RefreshTokens { get; set; }
    }
}