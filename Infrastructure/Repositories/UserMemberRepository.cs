using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities.Auth;

namespace Infrastructure.Repositories;
public class UserMemberRepository : GenericRepository<UserMember>, IUserMemberRepository
{
    protected readonly ApiHabitaDbContext _context;

    public UserMemberRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<UserMember?> GetByUserNameAsync(string userName)
    {
        return await _context.UserMembers
                            .Include(u => u.Roles)
                            .FirstOrDefaultAsync(u => u.Username.ToLower() == userName.ToLower());
    }
}