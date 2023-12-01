using Microsoft.AspNetCore.Identity;
using MyBlog_App.Data.Static;
using MyBlog_App.Models;

namespace MyBlog_App.Data
{
    public class AppDbInitializer
    {

      public static  async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var adminUserName = "admin-user";
                var adminUser = await userManager.FindByNameAsync(adminUserName);

                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                     
                        UserName = adminUserName,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Blog1*");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                var appUserName = "app-user";
                var appUser = await userManager.FindByNameAsync(appUserName);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        UserName = appUserName,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Blogapp1*");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
