using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class HabitRepository : GenericRepository<Habit>, IHabitRepository
{
    protected readonly ApiHabitaDbContext _context;

    public HabitRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}