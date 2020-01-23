using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BPS.View_Model
{
    public class JobPost
    {
        public int id { get; set; }
        [Required]
        [Display(Name="Building Name")]
        public string BuildingName { get; set; }
        [Required]
        [Display(Name="Building Type")]
        public Nullable<int> build_id { get; set; }
        [Required]
        [Display(Name = "Service Type")]
        public Nullable<int> Ser_id { get; set; }
        [Required]
        [Display(Name = "Land Size")]
        public string Land_Size { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public string Price { get; set; }

        public Nullable<int> LocID { get; set; }
        public Nullable<int> ClientID { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

    }
}