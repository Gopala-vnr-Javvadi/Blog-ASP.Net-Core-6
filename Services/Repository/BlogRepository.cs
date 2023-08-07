using Blog_ASP.Net_Core_6.Models;
using Blog_ASP.Net_Core_6.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Blog_ASP.Net_Core_6.Services.Repository
{
    public class BlogRepository : IBlogRepository
    {

        public UserModel GetProfile(string email)
        {
            return UserConstants.Users.Where(x => x.EmailAddress == email).FirstOrDefault();
        }

        public string GetProfileImageforComments(string email)
        {
            var query = (from h in UserConstants.Users
                         where h.EmailAddress.Equals(email)
                         select h.ImageUrl).FirstOrDefault();

            if (query != null) {
                return query.ToString();
            }
            return string.Empty;
        }

        public IEnumerable<BlogPost> GetBlogs()
        {
            return UserConstants.BlogPosts.ToList();
        }

        public BlogPost GetMyBlogById(int BlogId)
        {
            return UserConstants.BlogPosts.Where(x => x.BlogId == BlogId).First();

        }

        public IEnumerable<BlogPost> GetMyBlogs(string email)
        {
            return UserConstants.BlogPosts.Where(x => x.EmailAddress == email).ToList().OrderBy(x => x.CreatedDate);

        }


        public void CreateNewBlog(BlogPost objBlogPost)
        {
            var count = UserConstants.BlogPosts.Count() + 1;


            UserConstants.BlogPosts.Add(

                new BlogPost() {
                    BlogId = count,
                    Title = objBlogPost.Title,
                    EmailAddress = objBlogPost.EmailAddress,
                    Content = objBlogPost.Content,
                   // File = objBlogPost.File,
                   Image =objBlogPost.Image,
                    CreatedBy = objBlogPost.CreatedBy,
                    UpdatedBy = objBlogPost.UpdatedBy,
                    CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("dd-MMM-yyyy HH:mm:"),
                    UpdatedDate = objBlogPost.UpdatedDate,
                    Category = objBlogPost.Category
                });

                 
            
        }
        public IEnumerable<Comment> GetComments(int BlogId)
        {
            return UserConstants.Comment.Where(x => x.BlogId == BlogId).ToList();//.OrderBy(x => x.CreatedDate);
        }

      
        public void PostComment(Comment comment)
        {
            var countComment = UserConstants.Comment.Count() + 1;
            UserConstants.Comment.Add(
                new Comment()
                {
                    Id = countComment,
                    Content = comment.Content,
                    CreatedDate = DateTime.UtcNow.ToLocalTime().ToString("dd-MMM-yyyy HH:mm:ss"),
                    ImageName = comment.ImageName,
                    BlogId = comment.BlogId,
                    CreatedBy = comment.CreatedBy,
                    UpdatedDate = comment.UpdatedDate,
                }
            );
        }
    }

}
