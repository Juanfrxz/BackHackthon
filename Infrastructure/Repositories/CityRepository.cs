using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class CityRepository : GenericRepository<City>, ICityRepository
{
    protected readonly ApiHabitaDbContext _context;

    public CityRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}