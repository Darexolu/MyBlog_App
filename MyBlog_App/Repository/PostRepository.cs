using Microsoft.EntityFrameworkCore;
using MyBlog_App.Data;
using MyBlog_App.Models;

namespace MyBlog_App.Repository
{
    public class PostRepository: IPostRepository
    {
        private readonly AppDbContext _dbContext;

        public PostRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddLike(int postId, string userId)
        {
            var existingLike = _dbContext.LikeModels
                .FirstOrDefault(l => l.PostId == postId && l.UserId == userId);

            if (existingLike == null)
            {
                var newLike = new LikeModel
                {
                    PostId = postId,
                    UserId = userId
                };

                _dbContext.LikeModels.Add(newLike);
                _dbContext.SaveChanges();
            }

            // Return the updated likes count for the post
            return GetLikesCount(postId);
        }

        public int RemoveLike(int postId, string userId)
        {
            var existingLike = _dbContext.LikeModels
                .FirstOrDefault(l => l.PostId == postId && l.UserId == userId);

            if (existingLike != null)
            {
                _dbContext.LikeModels.Remove(existingLike);
                _dbContext.SaveChanges();
            }

            // Return the updated likes count for the post
            return GetLikesCount(postId);
        }

        private int GetLikesCount(int postId)
        {
            return _dbContext.LikeModels.Count(l => l.PostId == postId);
        }

        public PostModel GetPostById(int postId)
        {
            return _dbContext.PostModels.FirstOrDefault(p => p.Id == postId);
        }
        // Other methods for interacting with the post data
        public bool HasUserLikedPost(int postId, string userId)
        {
            // Check if there is a like record for the specified post and user
            return _dbContext.LikeModels.Any(like => like.PostId == postId && like.UserId == userId);
        }
        public int GetPostLikesCount(int postId)
        {
            var post = _dbContext.PostModels.Find(postId);

            // Assuming that LikesCount is a property in PostModel
            return post?.LikesCount ?? 0;
        }

        public void UpdateLikeState(int postId, string userId, bool isLiked)
        {
            var existingLike = _dbContext.LikeModels
                .FirstOrDefault(l => l.PostId == postId && l.UserId == userId);

            if (existingLike != null)
            {
                existingLike.IsLiked = isLiked;
                _dbContext.SaveChanges();
            }
            else
            {
                // Handle the case where the like doesn't exist, if needed
                // This could happen if the like state was not properly initialized before
            }
        }
    }
}
