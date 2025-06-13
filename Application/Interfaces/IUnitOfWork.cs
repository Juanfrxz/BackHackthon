namespace Application.Interfaces; 
public interface IUnitOfWork {
        IBlogRepository Blogs { get; }
        ICityRepository Cities { get; }
        IConstituentRepository Constituents { get; }
        IContactTypeRepository ContactTypes { get; }
        ICountryRepository Countries { get; }
        IEmotionalBlogRepository EmotionalBlogs { get; }
        IEmotionalCategoryRepository EmotionalCategories { get; }
        IEmotionalTypeRepository EmotionalTypes { get; }
        IHabitRepository Habits { get; }
        IMemberRepository Members { get; }
        IMemberRolRepository MemberRols { get; }
        IPersonHabitRepository PersonHabits { get; }
        IPersonProfileRepository PersonProfiles { get; }
        IPersonTypeRepository PersonTypes { get; }
        IPhonePersonRepository PhonePersons { get; }
        IPriorityLevelRepository PriorityLevels { get; }
        IProfessionalRepository Professionals { get; }
        IProfessionRepository Professions { get; }
        IRefreshTokenRepository RefreshTokens { get; }
        IRegionRepository Regions { get; }
        IRiskTypeRepository RiskTypes { get; }
        IRolRepository Rols { get; }
        ISpecialtieRepository Specialties { get; }
        ISpecialtyRepository Specialtys { get; }
        ISupportNetworkRepository SupportNetworks { get; }
        ITypeRelationRepository TypeRelations { get; }
        Task<int> SaveAsync(); 
} 
