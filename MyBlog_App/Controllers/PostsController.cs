﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MyBlog_App.Data;
using MyBlog_App.Models;
using MyBlog_App.Models.ViewModels;
using System.Diagnostics;
using Microsoft.Extensions.Hosting.Internal;

namespace MyBlog_App.Controllers
{
    public class PostsController : Controller
    {
        private readonly ILogger<PostsController> _logger;
        private readonly AppDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostsController(ILogger<PostsController> logger, AppDbContext dbcontext,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _dbContext = dbcontext;
            _webHostEnvironment = webHostEnvironment;
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
                    ImageUrl = post.ImageUrl,
                    CreatedAt = post.CreatedAt,
                    UpdatedAt = post.UpdatedAt
                }).ToList()
            };

            return postListViewModel;
        }
        public IActionResult NewPost()
        {
            var postViewModel = new PostViewModel
            {
                Post = new PostModel() // Initialize an empty PostModel
            };

            return View(postViewModel);
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
        public IActionResult Insert(PostViewModel newPost, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (imageFile != null && IsImageFile(imageFile.FileName))
                {
                    
                    // Save the image to a folder or a storage service
                    // In a real application, you would implement a service for handling file uploads
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    // For simplicity, this example saves the image to wwwroot/images folder
                    var imagePath = Path.Combine(wwwRootPath, @"images");
                    if(!string.IsNullOrEmpty(newPost.Post.ImageUrl))
                    {
                        //delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, newPost.Post.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var stream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    // Set the ImageUrl property in the PostModel
                    newPost.Post.ImageUrl = $"/images/{fileName}";
                }
                // Map PostModel to Post entity
                var postEntity = new PostModel
                {
                   
                    Title = newPost.Post.Title,
                    Body = newPost.Post.Body,
                    ImageUrl = newPost.Post.ImageUrl,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                try
                {
                    // Add the new post to the database
                    _dbContext.PostModels.Add(postEntity);
                    _dbContext.SaveChanges();

                    TempData["PostUpload"] = $"Post uploaded successfully ";
                    TempData["ShowToastr"] = true;
                    return RedirectToAction("Index");
                }
                catch
                {
                    TempData["error"] = "Invalid image format";
                }
            }

            // If the model state is not valid, return to the insert view with validation errors
            return View(newPost);
        }
        [NonAction]
        private bool IsImageFile(string fileName)
        {
            bool isValid = false;
            string[] fileExtensions = { ".jpg", ".png", ".jpeg", ".JPG", ".PNG", ".JPEG" };

            for (int i = 0; i < fileExtensions.Length; i++)
            {
                if (fileName.Contains(fileExtensions[i]))
                {
                    isValid = true;
                }
            }
            return isValid;
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