using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BRS.Models
{
    public class UserLogin
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string userName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        //[StringLength(100, ErrorMessage = "the {0} must be at least {2} character long", MinimumLength = 6)]
        public string Password { get; set; }
        [Display(Name = "User Role")]

        public int userRole { get; set; }
        public string RoleName { get; set; }



    }

    public class RegisterView
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "User Name")]
        [Remote("UserNameExist", "User", ErrorMessage = "Sorry, This User Name Already Exist")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "User Role")]
        public string userRole { get; set; }
    }
}