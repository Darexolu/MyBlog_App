namespace MyBlog_App.Repository
{
    public interface IPostRepository
    {
       
            int AddLike(int postId, string userId);
            int RemoveLike(int postId, string userId);
            // Other methods for interacting with the post data
        
    }
}
