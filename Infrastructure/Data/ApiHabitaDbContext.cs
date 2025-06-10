using Microsoft.EntityFrameworkCore; 
namespace Infrastructure.Data { 
    public class ApiHabitaDbContext : DbContext { 
        public ApiHabitaDbContext(DbContextOptions<ApiHabitaDbContext> options) : base(options) 
        {
            
        } 
    } 
} 
