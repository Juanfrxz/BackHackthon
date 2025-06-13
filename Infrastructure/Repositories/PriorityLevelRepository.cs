using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class PriorityLevelRepository : GenericRepository<PriorityLevel>, IPriorityLevelRepository
{
    protected readonly ApiHabitaDbContext _context;

    public PriorityLevelRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}