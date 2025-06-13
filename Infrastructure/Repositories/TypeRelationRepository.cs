using System.Linq;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Infrastructure.Repositories;
public class TypeRelationRepository : GenericRepository<TypeRelation>, ITypeRelationRepository
{
    protected readonly ApiHabitaDbContext _context;

    public TypeRelationRepository(ApiHabitaDbContext context) : base(context)
    {
        _context = context;
    }
}