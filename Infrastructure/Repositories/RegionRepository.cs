using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class RegionRepository : GenericRepository<Region>, IRegionRepository
{
    protected readonly ApiHabitaDbContext _context;

    public RegionRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}