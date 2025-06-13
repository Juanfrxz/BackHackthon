using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    protected readonly ApiHabitaDbContext _context;

    public CountryRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}