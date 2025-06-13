using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class RolRepository : GenericRepository<Rol>, IRolRepository
{
    protected readonly ApiHabitaDbContext _context;

    public RolRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}