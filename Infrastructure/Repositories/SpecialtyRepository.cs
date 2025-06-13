using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class SpecialtyRepository : GenericRepository<Specialty>, ISpecialtyRepository
{
    protected readonly ApiHabitaDbContext _context;

    public SpecialtyRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}