using Domain.Entities;

namespace Application.Interfaces;
public interface IConstituentRepository : IGenericRepository<Constituent>
{
    Task<Constituent?> GetByIdsAsync(int supportnetworkId, int priorityLevelId, int typeRelationId);
}