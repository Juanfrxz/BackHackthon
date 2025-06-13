using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class PhonePersonRepository : GenericRepository<PhonePerson>, IPhonePersonRepository
{
    protected readonly ApiHabitaDbContext _context;

    public PhonePersonRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}