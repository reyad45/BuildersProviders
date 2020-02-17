using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPS.Models
{
    public class Supplier
    {

        [Required]
        [Display(Name = "User Name")]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [Remote("UserNameExist", "User", ErrorMessage = "Sorry, This User Name Already Exist")]
        public string UserName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string RePassword { get; set; }


        public int id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [MinLength(3, ErrorMessage = "Minimum 3 Leter")]
        [Display(Name = "Supplier Name")]
        public string SupName { get; set; }
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Please enter a valid email")]
        [Required(ErrorMessage = "This Field is Required")]

        [Display(Name = "Supplier Email")]
        public string supEmail { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Contact Number")]
        public string supContact { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "About")]
        public string supAbout { get; set; }
        
        [Display(Name = "Address")]
        public string supAdress { get; set; }
        
        [Display(Name = "Country")]
        public string supCountry { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Gender")]
        public string supGender { get; set; }
        
        [Display(Name = "Picture")]
        public byte[] supPicture { get; set; }
        
        [Display(Name = "Details")]
        public string supDetails { get; set; }
        
        [Display(Name = "Profile")]
        public string supProfile { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Experience")]
        public string supExperience { get; set; }
        public string supEntryBy { get; set; }
        public Nullable<System.DateTime> engEntryDate { get; set; }
    }
}