using MyBlog_App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog_App.Models;
using static System.Net.Mime.MediaTypeNames;

namespace MyBlog_App.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
             
       }
        public DbSet<PostModel> PostModels { get; set; }
    }
}
