using AutoMapper; 
using Domain.Entities; 
using Application.DTOs.UserMember;
using Domain.Entities.Auth;
using Application.DTOs.Auth;
using Application.DTOs.Role;
using Application.DTOs.UserMemberRole;
using Application.DTOs.RefreshToken;
using Application.DTOs.Blog;
using Application.DTOs.City;
using Application.DTOs.Constituent;
using Application.DTOs.ContactType;
using Application.DTOs.Country;
using Application.DTOs.EmotionalBlog;
using Application.DTOs.EmotionalCategory;
using Application.DTOs.EmotionalType;
using Application.DTOs.Habit;
using Application.DTOs.PersonHabit;
using Application.DTOs.PersonProfile;
using Application.DTOs.PersonType;
using Application.DTOs.PhonePerson;
using Application.DTOs.PriorityLevel;
using Application.DTOs.Profession;
using Application.DTOs.Professional;
using Application.DTOs.Region;
using Application.DTOs.RiskType;
using Application.DTOs.Specialty;
using Application.DTOs.Specialtie;
using Application.DTOs.SupportNetwork;
using Application.DTOs.TypeRelation;
using System.Linq;

namespace Application.Profiles; 
public class MappingProfiles : Profile { 
        public MappingProfiles() { 
            // Auth mappings
            CreateMap<UserMember, UserMemberDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<UserMemberRole, UserMemberRoleDto>().ReverseMap();
            CreateMap<RefreshToken, RefreshTokenDto>()
                .ForMember(dest => dest.UserMemberId, opt => opt.MapFrom(src => src.MemberId))
                .ReverseMap()
                .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.UserMemberId));

            // Domain <-> DTO mappings
            CreateMap<Blog, BlogDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Constituent, ConstituentDto>().ReverseMap();
            CreateMap<ContactType, ContactTypeDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<EmotionalBlog, EmotionalBlogDto>().ReverseMap();
            CreateMap<EmotionalCategory, EmotionalCategoryDto>().ReverseMap();
            CreateMap<EmotionalType, EmotionalTypeDto>().ReverseMap();
            CreateMap<Habit, HabitDto>().ReverseMap();
            CreateMap<PersonHabit, PersonHabitDto>().ReverseMap();
            CreateMap<PersonProfile, PersonProfileDto>().ReverseMap();
            CreateMap<PersonType, PersonTypeDto>().ReverseMap();
            CreateMap<PhonePerson, PhonePersonDto>().ReverseMap();
            CreateMap<PriorityLevel, PriorityLevelDto>().ReverseMap();
            CreateMap<Profession, ProfessionDto>().ReverseMap();
            CreateMap<Professional, ProfessionalDto>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<RiskType, RiskTypeDto>().ReverseMap();
            CreateMap<Specialty, SpecialtyDto>().ReverseMap();
            CreateMap<Specialtie, SpecialtieDto>().ReverseMap();
            CreateMap<SupportNetwork, SupportNetworkDto>().ReverseMap();
            CreateMap<TypeRelation, TypeRelationDto>().ReverseMap();
        } 
} 