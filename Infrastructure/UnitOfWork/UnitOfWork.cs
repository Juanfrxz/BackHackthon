using Application.Interfaces; 
using Infrastructure.Data; 
namespace Infrastructure.UnitOfWork; 
public class UnitOfWork : IUnitOfWork,IDisposable 
{ 
   private readonly ApiHabitaDbContext _context; 
   public UnitOfWork(ApiHabitaDbContext context) 
   { 
       _context = context; 
   } 
   public void Dispose() 
   { 
       _context.Dispose(); 
   } 
   public async Task<int> SaveAsync() 
   { 
       return await _context.SaveChangesAsync(); 
   } 
} 
