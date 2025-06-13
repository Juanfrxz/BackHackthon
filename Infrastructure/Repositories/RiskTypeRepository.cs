using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class RiskTypeRepository : GenericRepository<RiskType>, IRiskTypeRepository
{
    protected readonly ApiHabitaDbContext _context;

    public RiskTypeRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}