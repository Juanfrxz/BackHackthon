using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class ProfessionRepository : GenericRepository<Profession>, IProfessionRepository
{
    protected readonly ApiHabitaDbContext _context;

    public ProfessionRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}