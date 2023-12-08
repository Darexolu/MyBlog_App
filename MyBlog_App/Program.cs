using Microsoft.EntityFrameworkCore;
using MyBlog_App.Data;
using System;
using Microsoft.AspNetCore.Identity;
using MyBlog_App.Models;
using MyBlog_App.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultUI().AddDefaultTokenProviders();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddAuthentication("LoginAuthentication")
    .AddCookie("LoginAuthentication", options =>
    {
        options.LoginPath = "/Account/Login"; // Specify your custom login path
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Posts}/{action=Index}/{id?}");
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
app.Run();
