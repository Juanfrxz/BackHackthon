using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class PersonTypeRepository : GenericRepository<PersonType>, IPersonTypeRepository
{
    protected readonly ApiHabitaDbContext _context;

    public PersonTypeRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}