using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class ContactTypeRepository : GenericRepository<ContactType>, IContactTypeRepository
{
    protected readonly ApiHabitaDbContext _context;

    public ContactTypeRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}