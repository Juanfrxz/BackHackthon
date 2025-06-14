using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities.Auth;

namespace Infrastructure.Repositories;
public class UserMemberRoleRepository : GenericRepository<UserMemberRole>, IUserMemberRoleRepository
{
    protected readonly ApiHabitaDbContext _context;

    public UserMemberRoleRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<UserMemberRole?> GetByIdsAsync(int userMemberId, int roleId)
    {
        throw new NotImplementedException();
    }
}