using static MyBlog_App.Repository.IPostRepository;

namespace MyBlog_App.Repository
{
    public class PostService: IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public int LikePost(int postId, string userId)
        {
            // Implement logic to add a like for the user to the specified post
            // You might need to interact with a repository to update the database
            var updatedLikesCount = _postRepository.AddLike(postId, userId);

            return updatedLikesCount;
        }

        public int UnlikePost(int postId, string userId)
        {
            // Implement logic to remove the like for the user from the specified post
            // You might need to interact with a repository to update the database
            var updatedLikesCount = _postRepository.RemoveLike(postId, userId);

            return updatedLikesCount;
        }
    }
}
