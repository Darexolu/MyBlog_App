using Microsoft.Extensions.Hosting;
using MyBlog_App.Models;

namespace MyBlog_App.Repository
{
    public interface IPostRepository
    {
       
            int AddLike(int postId, string userId);
            int RemoveLike(int postId, string userId);
        PostModel GetPostById(int postId);
        bool HasUserLikedPost(int postId, string userId);
        int GetPostLikesCount(int postId);
        void UpdateLikeState(int postId, string userId, bool isLiked);
        // Other methods for interacting with the post data

    }
}
