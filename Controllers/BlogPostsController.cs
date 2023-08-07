using Blog_ASP.Net_Core_6.Data;
using Blog_ASP.Net_Core_6.Models;
using Blog_ASP.Net_Core_6.Services.Interface;
using Blog_ASP.Net_Core_6.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_ASP.Net_Core_6.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private IHostingEnvironment hostingEnv;
        private IBlogRepository @object;
        private readonly BlogDBContext _dbContext;
        private readonly IBlogRepository _blogRepository;
        private readonly string _path = "";

        private readonly IWebHostEnvironment _environment;

        //public BlogPostsController(IBlogRepository blogRepository)
        //{
        //    _blogRepository = blogRepository;
        //}
        public BlogPostsController(IWebHostEnvironment environment, IBlogRepository blogRepository)
        {
            _environment = environment;
            _blogRepository = blogRepository;
        }

       

        [HttpPost("File")]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromForm] BlogPost objBlogPost)
        {

            var pathNameOnly = string.Empty;
            if (file != null || file.Length != 0)
            {
                //  return BadRequest("File not selected or invalid file.");


                // Process the file and otherData here as needed
                // For example, save the file to a database or storage, etc.

                // Save the uploaded file to the "uploads" folder
                var uploadsPath = Path.Combine(_environment.ContentRootPath, "Images");
                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }
                string filenameOnly = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string dateTime = DateTime.UtcNow.ToLocalTime().ToString("ddMMyyyyHHmmss");

                var fileName = Path.Combine(uploadsPath, filenameOnly + dateTime + extension);
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                 pathNameOnly = "https://localhost:7086/" + "Images/" + filenameOnly + dateTime + extension;
            }

            if (objBlogPost != null)
            {
                objBlogPost.Image = pathNameOnly;
                _blogRepository.CreateNewBlog(objBlogPost);
              // return Ok($"Your New post is Created and posted");
            }
            
            return Ok(new { message = "Upload successful!", objBlogPost });
        }


        [HttpPost("CreateComment")]
        // [Authorize(Roles = "User")]//done//mo
        public IActionResult CreateComment(Comment objPostComment)
        {
            if (objPostComment != null)
            {
                _blogRepository.PostComment(objPostComment);
            }
            return Ok("User your comment is posted");
        }



        [HttpGet("MyProfile")]
        [AllowAnonymous]
        public IActionResult GetProfile(string email)
        {
            UserModel objProfile = _blogRepository.GetProfile(email);
            if (objProfile != null)
            {
                return Ok(objProfile);
            }
            return NotFound("No Profile");

        }

        [HttpGet("GetMyBlogById")]
        [AllowAnonymous]
        public IActionResult GetMyBlogById(int BlogId)
        {
            BlogPost objBlogPostById = _blogRepository.GetMyBlogById(BlogId);
            if (objBlogPostById != null)
            {
                return Ok(objBlogPostById);
            }
            return NotFound("No Blog");

        }
        

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBlogPosts()
        {
            IEnumerable<BlogPost> objGetBlogPost = _blogRepository.GetBlogs();
            if (objGetBlogPost != null)
            {
                return Ok(objGetBlogPost);
            }
            return NotFound("No Blogs");
        }
        
        [HttpGet("GetComments")]
        [AllowAnonymous]
        public IActionResult GetBlogComments(int BlogId)
        {

            IEnumerable<Comment> objPostComments = _blogRepository.GetComments(BlogId);
           
            if (objPostComments != null)
            {
                foreach (var item in objPostComments)
                {
                    item.ImageSrc = _blogRepository.GetProfileImageforComments(item.CreatedBy);

                }            
                return Ok(objPostComments);
            }
            return NotFound("User not found");
        }



        [HttpGet("MyBlogs")]
        // [Authorize(Roles = "User")]
        public IActionResult GetMyBlogs(string email)
        {
            IEnumerable<BlogPost> objGetMyBlogs = _blogRepository.GetMyBlogs(email);
          
            if (objGetMyBlogs != null)
            {
                return Ok(objGetMyBlogs);
            }
            return NotFound("No Blogs");

        }

    }
}
