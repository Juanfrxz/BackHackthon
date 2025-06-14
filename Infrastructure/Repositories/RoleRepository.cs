using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities.Auth;

namespace Infrastructure.Repositories;
public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    protected readonly ApiHabitaDbContext _context;

    public RoleRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}