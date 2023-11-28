using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MyBlog_App.Data;
using MyBlog_App.Models;
using MyBlog_App.Models.ViewModels;
using System.Diagnostics;

namespace MyBlog_App.Controllers
{
    public class PostsController : Controller
    {
        private readonly ILogger<PostsController> _logger;
        private readonly AppDbContext _dbContext;

        public PostsController(ILogger<PostsController> logger, AppDbContext dbcontext)
        {
            _logger = logger;
            _dbContext = dbcontext;
        }

        public IActionResult Index()
        {
            var postListViewModel = GetAllPosts();
            return View(postListViewModel);
        }
        private PostViewModel GetAllPosts()
        {
            var posts = _dbContext.PostModels.ToList(); // Assuming you have a DbSet<Post> in your AppDbContext

            var postListViewModel = new PostViewModel
            {
                PostList = posts.Select(post => new PostModel
                {
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body,
                    CreatedAt = post.CreatedAt,
                    UpdatedAt = post.UpdatedAt
                }).ToList()
            };

            return postListViewModel;
        }
        public IActionResult NewPost()
        {
            return View();
        }
        public IActionResult ViewPost(int id)
        {
            var post = GetPostById(id);
            var postViewModel = new PostViewModel();
            postViewModel.Post = post;
            return View(postViewModel);
        }
        public IActionResult EditPost(int id)
        {
            var post = GetPostById(id);
            var postViewModel = new PostViewModel();
            postViewModel.Post = post;
            return View(postViewModel);
        }
        private PostModel GetPostById(int id)
        {
            var postEntity = _dbContext.PostModels.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if (postEntity != null)
            {
                // Map the Post entity to a PostModel
                var postModel = new PostModel
                {
                    Id = postEntity.Id,
                    Title = postEntity.Title,
                    Body = postEntity.Body,
                    CreatedAt = postEntity.CreatedAt,
                    UpdatedAt = postEntity.UpdatedAt
                };

                return postModel;
            }

            // Handle the case where the post with the given id is not found
            return null;
        }
        public IActionResult Insert()
        {
            var postViewModel = new PostViewModel
            {
                Post = new PostModel() // Initialize an empty PostModel
            };

            return View(postViewModel);
        }

        [HttpPost]
        public IActionResult Insert(PostViewModel newPost)
        {
            if (ModelState.IsValid)
            {
                // Map PostModel to Post entity
                var postEntity = new PostModel
                {
                   
                    Title = newPost.Post.Title,
                    Body = newPost.Post.Body,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                // Add the new post to the database
                _dbContext.PostModels.Add(postEntity);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            // If the model state is not valid, return to the insert view with validation errors
            return View(newPost);
        }
        public IActionResult Update(int id)
        {
            var post = GetPostById(id);

            if (post == null)
            {
                // Handle the case where the post with the given id is not found
                return NotFound();
            }

            var postViewModel = new PostViewModel
            {
                Post = post
            };

            return View(postViewModel);
        }

        [HttpPost]
        public IActionResult Update(PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                var postId = postViewModel.Post.Id;
                var postEntity = GetPostById(postId);

                if (postEntity == null)
                {
                    // Handle the case where the post with the given id is not found
                    return NotFound();
                }

                // Update the post entity with the new values
                postEntity.Title = postViewModel.Post.Title;
                postEntity.Body = postViewModel.Post.Body;
                postEntity.UpdatedAt = DateTime.Now;

                try
                {
                    // Attach the entity to the context
                    _dbContext.Attach(postEntity).State = EntityState.Modified;

                    // Save changes to the database
                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                    Console.WriteLine($"Error saving changes to the database: {ex.Message}");
                }
            }

            // If the model state is not valid, return to the update view with validation errors
            return View(postViewModel);
        }
       
        public IActionResult DeletePost(int id)
        {
            var post = GetPostById(id);

            if (post == null)
            {
                // Handle the case where the post with the given id is not found
                return NotFound();
            }

            var postViewModel = new PostViewModel
            {
                Post = post
            };

            return View(postViewModel);
        }

        public IActionResult Delete(/*int id*/)
        {
            //var post = GetPostById(id);

            //if (post == null)
            //{
            //    // Handle the case where the post with the given id is not found
            //    return NotFound();
            //}

            //var postViewModel = new PostViewModel
            //{
            //    Post = post
            //};

            return View(/*postViewModel*/);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var post = GetPostById(id);

            if (post == null)
            {
                // Handle the case where the post with the given id is not found
                return NotFound();
            }

           
                _dbContext.PostModels.Remove(post);
                _dbContext.SaveChanges();
            TempData["PostDeleted"] = $"The post with title \"{post.Title}\" has been successfully deleted.";

            // Use Toastr to display notification
            TempData["ShowToastr"] = true;
           
            return RedirectToAction("index");
           
        }
      
        public IActionResult DeleteConfirmation(int id)
        {
            var post = GetPostById(id);

            if (post == null)
            {
                // Handle the case where the post with the given id is not found
                return NotFound();
            }

            var postViewModel = new PostViewModel
            {
                Post = post
            };

            return View(postViewModel);
        }


    }
}