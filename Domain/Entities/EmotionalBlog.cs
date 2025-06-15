namespace Domain.Entities;  
public class EmotionalBlog : BaseEntity 
{
       public int EmotionalTypeId { get; set; }
      public EmotionalType EmotionalTypes { get; set; }
      public int BlogId { get; set; }
      public Blog Blogs { get; set; }
}