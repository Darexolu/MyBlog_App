﻿using MyBlog_App.Data;
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
    

    // Other methods for interacting with the post data

   
}
}