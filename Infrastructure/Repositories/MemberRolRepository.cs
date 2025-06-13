using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class MemberRolRepository : GenericRepository<MemberRol>, IMemberRolRepository
{
    protected readonly ApiHabitaDbContext _context;

    public MemberRolRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}