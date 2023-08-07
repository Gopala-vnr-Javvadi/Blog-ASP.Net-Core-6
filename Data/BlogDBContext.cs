using Blog_ASP.Net_Core_6.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Blog_ASP.Net_Core_6.Data
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
