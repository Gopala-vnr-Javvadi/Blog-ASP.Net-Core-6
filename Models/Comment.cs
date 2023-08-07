using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_ASP.Net_Core_6.Models
{
    public class Comment
    {

        public int Id { get; set; }
        public string Content { get; set; } 
        public string CreatedBy { get; set; } 
        public string CreatedDate { get; set; }
        public string? ImageName { get; set; } = null;
       // [NotMapped]
       // public IFormFile File { get; set; }
        public string ImageSrc { get; set; }
        public int BlogId { get; set; }
        public string? UpdatedBy { get; set; } = null;
        public DateTime? UpdatedDate { get; set; } = null;
            
    }
}
