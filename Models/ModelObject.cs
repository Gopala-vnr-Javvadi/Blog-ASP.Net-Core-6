namespace Blog_ASP.Net_Core_6.Models
{
    public class ModelObject
    {
        public IEnumerable<BlogPost> BlogPost { get; set; }
        public IEnumerable<Comment> Comment { get; set; }

        public IEnumerable<UserModel> UserModel { get; set; }
    }
}
