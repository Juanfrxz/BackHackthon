namespace Domain.Entities;  
public class EmotionalType : BaseEntity 
{ 
       public int Id { get; set; } 
       public string Description { get; set; }
       public int EmotionalCategoryId { get; set; }
       public EmotionalCategory EmotionalCategorys { get; set; }
       public ICollection<EmotionalBlog> EmotionalBlogs { get; set; }
}