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
}