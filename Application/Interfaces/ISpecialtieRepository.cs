using Domain.Entities;

namespace Application.Interfaces;
public interface ISpecialtieRepository : IGenericRepository<Specialtie>
{
    Task<Specialtie?> GetByIdsAsync(int specialtyId, int professionalId);
}