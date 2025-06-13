using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class PersonProfileRepository : GenericRepository<PersonProfile>, IPersonProfileRepository
{
    protected readonly ApiHabitaDbContext _context;

    public PersonProfileRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}