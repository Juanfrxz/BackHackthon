using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities.Auth;

namespace Infrastructure.Repositories;
public class UserMemberRolRepository : GenericRepository<UserMemberRoles>, IUserMemberRolRepository
{
    protected readonly ApiHabitaDbContext _context;

    public UserMemberRolRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}