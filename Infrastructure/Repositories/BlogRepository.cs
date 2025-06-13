using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class BlogRepository : GenericRepository<Blog>, IBlogRepository
{
    protected readonly ApiHabitaDbContext _context;

    public BlogRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}