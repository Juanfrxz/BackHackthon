using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities.Auth;

namespace Infrastructure.Repositories;
public class MemberRepository : GenericRepository<UserMember>, IMemberRepository
{
    protected readonly ApiHabitaDbContext _context;

    public MemberRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}