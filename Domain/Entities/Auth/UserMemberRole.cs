using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Auth
{
    public class UserMemberRole
    {
        public int UserMemberId { get; set; }
        public UserMember UserMembers { get; set; } = null!;
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}