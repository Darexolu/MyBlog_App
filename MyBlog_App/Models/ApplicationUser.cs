using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog_App.Models
{
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
        {
        }
        //[Display(Name = "User name")]
        //public string userName { get; set; }
    }
}
