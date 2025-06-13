using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class EmotionalBlogRepository : GenericRepository<EmotionalBlog>, IEmotionalBlogRepository
{
    protected readonly ApiHabitaDbContext _context;

    public EmotionalBlogRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}