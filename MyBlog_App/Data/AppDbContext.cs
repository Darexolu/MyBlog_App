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
        public DbSet<LikeModel> LikeModels { get; set; }
        public DbSet<CommentModel> CommentModels { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Add any additional configurations

        //    // Define relationships
        //    modelBuilder.Entity<LikeModel>()
        //        .HasKey(like => new { like.UserId, like.PostId });

        //    modelBuilder.Entity<CommentModel>()
        //        .HasKey(comment => new { comment.Id });
        //}
    }
}
