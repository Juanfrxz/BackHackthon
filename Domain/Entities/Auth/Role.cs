using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Auth
{
    public class Role : BaseEntity 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserMember> UsersMembers { get; set;} = new HashSet<UserMember>();
        public ICollection<UserMemberRole> UserMemberRoles { get; set; }
    }
}