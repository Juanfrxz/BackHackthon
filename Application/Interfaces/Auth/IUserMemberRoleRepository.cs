using Domain.Entities;
using Domain.Entities.Auth;

namespace Application.Interfaces;
public interface IUserMemberRoleRepository : IGenericRepository<UserMemberRole>
{
    Task<UserMemberRole?> GetByIdsAsync(int userMemberId, int roleId);
}