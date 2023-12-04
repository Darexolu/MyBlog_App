namespace MyBlog_App.Repository
{
    public interface IPostService
    {
        int LikePost(int postId, string userId);
        int UnlikePost(int postId, string userId);
    }
}
