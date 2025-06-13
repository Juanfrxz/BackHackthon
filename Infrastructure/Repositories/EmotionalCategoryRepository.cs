using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class EmotionalCategoryRepository : GenericRepository<EmotionalCategory>, IEmotionalCategoryRepository
{
    protected readonly ApiHabitaDbContext _context;

    public EmotionalCategoryRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}