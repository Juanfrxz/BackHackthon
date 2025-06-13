using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class SpecialtieRepository : GenericRepository<Specialtie>, ISpecialtieRepository
{
    protected readonly ApiHabitaDbContext _context;

    public SpecialtieRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}