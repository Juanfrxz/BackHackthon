using Domain.Entities;

namespace Application.Interfaces;
public interface IEmotionalBlogRepository : IGenericRepository<EmotionalBlog>
{
    Task<EmotionalBlog?> GetByIdsAsync(int emotionalTypeId, int blogId);
}