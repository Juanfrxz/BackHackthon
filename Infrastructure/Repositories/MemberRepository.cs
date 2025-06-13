using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class MemberRepository : GenericRepository<Member>, IMemberRepository
{
    protected readonly ApiHabitaDbContext _context;

    public MemberRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}