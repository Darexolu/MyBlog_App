using Microsoft.EntityFrameworkCore;
using MyBlog_App.Models;

namespace MyBlog_App.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
             
       }
        public DbSet<PostModel> PostModels { get; set; }
    }
}
