using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class SupportNetworkRepository : GenericRepository<SupportNetwork>, ISupportNetworkRepository
{
    protected readonly ApiHabitaDbContext _context;

    public SupportNetworkRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}