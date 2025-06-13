using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class ConstituentRepository : GenericRepository<Constituent>, IConstituentRepository
{
    protected readonly ApiHabitaDbContext _context;

    public ConstituentRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}