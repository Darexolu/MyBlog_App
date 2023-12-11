// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

        // JavaScript to toggle post body visibility
        $(document).ready(function () {
            $(".toggle-body").click(function () {
                $(this).prev(".full-body").toggle();
            });
        });
   //IncrementLikes
        function incrementLikes(postId) {
            var likeButton = $(`[data-post-id="${postId}"]`);
            var likeUrl = likeButton.data('like-url');
            var unlikeUrl = likeButton.data('unlike-url');
            var isLiked = likeButton.data('is-liked');

            $.ajax({
                type: 'POST',
                url: isLiked ? '/Posts/Unlike': '/Posts/Like',
                data: { postId: postId },
                success: function (data) {
                    var likesCountElement = likeButton.closest('.like-section').find('.likes-count');
                    likesCountElement.text(data.likesCount);

                    if (data.isLiked) {
                        likeButton.addClass('liked');
                        likeButton.text('Unlike');
                        likesCountElement.text(data.likesCount);
                    } else {
                        likeButton.removeClass('liked');
                        likeButton.text('Like');
                        likesCountElement.text(data.likesCount);
                    }
                     likeButton.data('is-liked', !isLiked);
                },
                error: function () {
                    console.error('Error in like/unlike operation');
                }
            });
        }

        $(document).ready(function () {
            $('.like-button').on('click', function () {
                var postId = $(this).data('post-id');
                incrementLikes(postId);
            });
        });
function showReplyForm(commentId) {
    var form = $(`#replyForm_${commentId}`);
    form.toggle();
}