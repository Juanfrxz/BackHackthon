using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{

    public class ApiHabitaDbContext : DbContext
    {
        public ApiHabitaDbContext(DbContextOptions<ApiHabitaDbContext> options) : base(options) { }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Constituent> Constituents { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EmotionalBlog> EmotionalBlogs { get; set; }
        public DbSet<EmotionalCategory> EmotionalCategorys { get; set; }
        public DbSet<EmotionalType> EmotionalTypes { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberRol> MemberRoles { get; set; }
        public DbSet<PersonHabit> PersonHabits { get; set; }
        public DbSet<PersonProfile> PersonProfiles { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<SupportNetwork> SupportNetworks { get; set; }
        public DbSet<TypeRelation> TypeRelations { get; set; }
        public DbSet<RiskType> RiskTypes { get; set; }
        public DbSet<Role> Rols { get; set; }
        public DbSet<Specialtie> SpecialtiesLinks { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<PriorityLevel> PriorityLevels { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Professional> Professionals { get; set; }
        public DbSet<PhonePerson> PhonePersons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

}
