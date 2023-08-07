using Blog_ASP.Net_Core_6.Models;
using Blog_ASP.Net_Core_6.Services.Repository;

namespace Blog_ASP.Net_Core_6.Services.Interface
{
    public interface IBlogRepository
    {

        UserModel GetProfile(string email);

        string GetProfileImageforComments(string email);
        BlogPost GetMyBlogById(int BlogId);
        IEnumerable<BlogPost> GetBlogs();

        IEnumerable<BlogPost> GetMyBlogs(string email);
        void CreateNewBlog(BlogPost objPostBlog);
        IEnumerable<Comment> GetComments(int BlogId);
        void PostComment(Comment objPostComment);
    }
}
