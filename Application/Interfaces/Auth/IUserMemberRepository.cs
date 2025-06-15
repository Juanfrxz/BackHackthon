using Domain.Entities;
using Domain.Entities.Auth;

namespace Application.Interfaces;
public interface IUserMemberRepository : IGenericRepository<UserMember>
{
    Task<UserMember?> GetByUserNameAsync (string userName);
}