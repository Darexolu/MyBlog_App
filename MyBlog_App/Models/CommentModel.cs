namespace MyBlog_App.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PostId { get; set; } // Foreign key to associate the comment with a post
        public string UserId { get; set; }
        public string UserName { get; set; } 
    }
}
