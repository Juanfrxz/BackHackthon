using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable 
{
    private readonly ApiHabitaDbContext _context;
    private IBlogRepository? _blogs;
    private ICityRepository? _cities;
    private IConstituentRepository? _constituents;
    private IContactTypeRepository? _contactTypes;
    private ICountryRepository? _countries;
    private IEmotionalBlogRepository? _emotionalBlogs;
    private IEmotionalCategoryRepository? _emotionalCategories;
    private IEmotionalTypeRepository? _emotionalTypes;
    private IHabitRepository? _habits;
    private IMemberRolRepository? _memberRols;
    private IPersonHabitRepository? _personHabits;
    private IPersonProfileRepository? _personProfiles;
    private IPersonTypeRepository? _personTypes;
    private IPhonePersonRepository? _phonePersons;
    private IPriorityLevelRepository? _priorityLevels;
    private IProfessionalRepository? _professionals;
    private IProfessionRepository? _professions;
    private IRefreshTokenRepository? _refreshTokens;
    private IRegionRepository? _regions;
    private IRiskTypeRepository? _riskTypes;
    private IRolRepository? _rols;
    private ISpecialtieRepository? _specialties;
    private ISpecialtyRepository? _specialtys;
    private ISupportNetworkRepository? _supportNetworks;
    private ITypeRelationRepository? _typeRelations;
    private IUserMemberRepository? _userMembers;
   public UnitOfWork(ApiHabitaDbContext context) 
   { 
       _context = context; 
   }
   public IBlogRepository Blogs{
        get
        {
            if (_blogs == null)
            {
                _blogs = new BlogRepository (_context);
            }
            return _blogs;
        }
    }
    public ICityRepository Cities{
          get
          {
                if (_cities == null)
                {
                 _cities = new CityRepository (_context);
                }
                return _cities;
          }
     }
    public IConstituentRepository Constituents{
        get
        {
            if (_constituents == null)
            {
                _constituents = new ConstituentRepository (_context);
            }
            return _constituents;
        }
    }
    public IContactTypeRepository ContactTypes{
        get
        {
            if (_contactTypes == null)
            {
                _contactTypes = new ContactTypeRepository (_context);
            }
            return _contactTypes;
        }
    }
    public ICountryRepository Countries{
        get
        {
            if (_countries == null)
            {
                _countries = new CountryRepository (_context);
            }
            return _countries;
        }
    }
    public IEmotionalBlogRepository EmotionalBlogs{
        get
        {
            if (_emotionalBlogs == null)
            {
                _emotionalBlogs = new EmotionalBlogRepository (_context);
            }
            return _emotionalBlogs;
        }
    }
    public IEmotionalCategoryRepository EmotionalCategories{
        get
        {
            if (_emotionalCategories == null)
            {
                _emotionalCategories = new EmotionalCategoryRepository (_context);
            }
            return _emotionalCategories;
        }
    }
    public IEmotionalTypeRepository EmotionalTypes{
        get
        {
            if (_emotionalTypes == null)
            {
                _emotionalTypes = new EmotionalTypeRepository (_context);
            }
            return _emotionalTypes;
        }
    }
    public IHabitRepository Habits{
        get
        {
            if (_habits == null)
            {
                _habits = new HabitRepository (_context);
            }
            return _habits;
        }
    }
    public IUserMemberRepository UserMembers{
        get
        {
            if (_userMembers == null)
            {
                _userMembers = new UserMemberRepository (_context);
            }
            return _userMembers;
        }
    }
    public IMemberRolRepository MemberRols{
        get
        {
            if (_memberRols == null)
            {
                _memberRols = new MemberRolRepository (_context);
            }
            return _memberRols;
        }
    }
    public IPersonHabitRepository PersonHabits{
        get
        {
            if (_personHabits == null)
            {
                _personHabits = new PersonHabitRepository (_context);
            }
            return _personHabits;
        }
    }
    public IPersonProfileRepository PersonProfiles{
        get
        {
            if (_personProfiles == null)
            {
                _personProfiles = new PersonProfileRepository (_context);
            }
            return _personProfiles;
        }
    }
    public IPersonTypeRepository PersonTypes{
        get
        {
            if (_personTypes == null)
            {
                _personTypes = new PersonTypeRepository (_context);
            }
            return _personTypes;
        }
    }
    public IPhonePersonRepository PhonePersons{
        get
        {
            if (_phonePersons == null)
            {
                _phonePersons = new PhonePersonRepository (_context);
            }
            return _phonePersons;
        }
    }
    public IPriorityLevelRepository PriorityLevels{
        get
        {
            if (_priorityLevels == null)
            {
                _priorityLevels = new PriorityLevelRepository (_context);
            }
            return _priorityLevels;
        }
    }
    public IProfessionalRepository Professionals{
        get
        {
            if (_professionals == null)
            {
                _professionals = new ProfessionalRepository (_context);
            }
            return _professionals;
        }
    }
    public IProfessionRepository Professions{
        get
        {
            if (_professions == null)
            {
                _professions = new ProfessionRepository (_context);
            }
            return _professions;
        }
    }
    public IRefreshTokenRepository RefreshTokens{
        get
        {
            if (_refreshTokens == null)
            {
                _refreshTokens = new RefreshTokenRepository (_context);
            }
            return _refreshTokens;
        }
    }
    public IRegionRepository Regions{
        get
        {
            if (_regions == null)
            {
                _regions = new RegionRepository (_context);
            }
            return _regions;
        }
    }
    public IRiskTypeRepository RiskTypes{
        get
        {
            if (_riskTypes == null)
            {
                _riskTypes = new RiskTypeRepository (_context);
            }
            return _riskTypes;
        }
    }
    public IRolRepository Rols{
        get
        {
            if (_rols == null)
            {
                _rols = new RolRepository (_context);
            }
            return _rols;
        }
    }
    public ISpecialtieRepository Specialties{
        get
        {
            if (_specialties == null)
            {
                _specialties = new SpecialtieRepository (_context);
            }
            return _specialties;
        }
    }
    public ISpecialtyRepository Specialtys{
        get
        {
            if (_specialtys == null)
            {
                _specialtys = new SpecialtyRepository (_context);
            }
            return _specialtys;
        }
    }
    public ISupportNetworkRepository SupportNetworks{
        get
        {
            if (_supportNetworks == null)
            {
                _supportNetworks = new SupportNetworkRepository (_context);
            }
            return _supportNetworks;
        }
    }
    public ITypeRelationRepository TypeRelations{
        get
        {
            if (_typeRelations == null)
            {
                _typeRelations = new TypeRelationRepository (_context);
            }
            return _typeRelations;
        }
    }
   public async Task<int> SaveAsync() 
   { 
       return await _context.SaveChangesAsync(); 
   } 
   public void Dispose() 
   { 
       _context.Dispose(); 
   } 
} 
