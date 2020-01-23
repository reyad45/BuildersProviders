using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BPS.Models
{
    public class ClientProfile
    {

        [Required]
        [Display(Name="User Name")]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [Remote("UserNameExist", "User", ErrorMessage="Sorry, This User Name Already Exist")]
        public string UserName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage ="The {0} must be at least {2} characters long.", MinimumLength=6)]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string RePassword { get; set; }
    

        public int id { get; set; }
        [Display(Name="Name")]
        [Required(ErrorMessage="Please Entry Your Name")]
        public string Name { get; set; }
        [Display(Name="Email")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Please enter a valid email")]
        [Required(ErrorMessage="Please Entry Your Email")]
        [Remote("IsEmailExist", "Client", ErrorMessage = "Email already exist")]
        public string Email { get; set; }
        [Required(ErrorMessage="Please Entry Your Phone Number")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "Phone Number should be between 11 to 15 charcter")]
        [Remote("IsNumberExist", "Client", ErrorMessage="Phone Number already exist")]
        public  string Phone { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Address should be between 10 to 200 charcter")]
        public string Address { get; set; }


    }
}