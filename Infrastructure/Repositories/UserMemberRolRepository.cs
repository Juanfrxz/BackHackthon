using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities.Auth;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;
public class UserMemberRoleRepository : IUserMemberRoleRepository
{
    protected readonly ApiHabitaDbContext _context;

    public UserMemberRoleRepository(ApiHabitaDbContext context) 
    {
        _context = context;
    }

 

    public Task<IEnumerable<UserMemberRole>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserMemberRole?> GetByIdsAsync(int userMemberId, int roleId)
    {
        throw new NotImplementedException();
    }

    public void Remove(UserMemberRole entity)
    {
        throw new NotImplementedException();
    }

    public void Update(UserMemberRole entity)
    {
        throw new NotImplementedException();
    }
}