using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class ProfessionalRepository : GenericRepository<Professional>, IProfessionalRepository
{
    protected readonly ApiHabitaDbContext _context;

    public ProfessionalRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}