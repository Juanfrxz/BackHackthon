using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Auth
{
    public class UserMemberRoles : BaseEntity 
    {
        public int MemberId { get; set; }
        public UserMember? UserMember { get; set; }
        public int RolId { get; set; }
        public Role? Role { get; set; }
    }
}