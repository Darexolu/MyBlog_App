﻿using Microsoft.AspNetCore.Mvc;
using MyBlog_App.Models;
using System.Diagnostics;

namespace MyBlog_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

     
       
    }
}