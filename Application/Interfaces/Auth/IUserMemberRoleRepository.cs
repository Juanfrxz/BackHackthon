using System.Linq.Expressions;
using Domain.Entities;
using Domain.Entities.Auth;

namespace Application.Interfaces;

public interface IUserMemberRoleRepository
{
    Task<IEnumerable<UserMemberRole>> GetAllAsync();
    void Remove(UserMemberRole entity);
    void Update(UserMemberRole entity);
    Task<UserMemberRole?> GetByIdsAsync(int userMemberId, int roleId);
}