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

        ///Replies
        public virtual CommentModel ParentComment { get; set; }
        // New property to represent the parent comment
        public int? ParentCommentId { get; set; }
        public int Depth { get; set; }
        public virtual List<CommentModel> Replies { get; set; }
        public string ReplyToUserName { get; set; }
        public string ReplyToCommentText { get; set; }
    }
}
