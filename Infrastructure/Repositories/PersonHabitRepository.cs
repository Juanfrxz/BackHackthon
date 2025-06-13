using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class PersonHabitRepository : GenericRepository<PersonHabit>, IPersonHabitRepository
{
    protected readonly ApiHabitaDbContext _context;

    public PersonHabitRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}