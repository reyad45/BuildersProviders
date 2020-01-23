//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace BPS.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    
    public partial class Engineer
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
        [Display(Name = "Engineer Name")]
        public string engName { get; set; }
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Please enter a valid email")]
        [Required(ErrorMessage = "This Field is Required")]

        [Display(Name = "Engineer Email")]
        public string engEmail { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Contact Number")]
        public string engContact { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "About")]
        public string engAbout { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Address")]
        public string engAdress { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Country")]
        public string engCountry { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Gender")]
        public string engGender { get; set; }
        [Required]
        [Display(Name = "Picture")]
        public byte[] engPicture{ get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Details")]
        public string engDetails { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Profile")]
        public string engProfile { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Experience")]
        public string engExperience { get; set; }
        public string engEntryBy { get; set; }
        public Nullable<System.DateTime> engEntryDate { get; set; }
    }
}
