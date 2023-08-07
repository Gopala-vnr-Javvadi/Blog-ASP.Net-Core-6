using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace Blog_ASP.Net_Core_6.Models
{
    public class BlogPost
    {
        [Key]
        public int BlogId { get; set; }

          
        public string Title { get; set; }

          
        public string EmailAddress { get; set; }

          
        public string Content { get; set; }


        public IFormFile File { get; set; }



        public string? Image { get; set; }


        public string? CreatedBy{ get; set; }

          
        public string? UpdatedBy { get; set; }

          
        public string ? CreatedDate { get; set; }

          
        public string? UpdatedDate { get; set; }

          
        public string Category { get;  set; }

          
       // public List<Comment> Comments { get; set; }

    }
}
