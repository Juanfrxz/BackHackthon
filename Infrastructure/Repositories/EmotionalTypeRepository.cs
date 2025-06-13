using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class EmotionalTypeRepository : GenericRepository<EmotionalType>, IEmotionalTypeRepository
{
    protected readonly ApiHabitaDbContext _context;

    public EmotionalTypeRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}