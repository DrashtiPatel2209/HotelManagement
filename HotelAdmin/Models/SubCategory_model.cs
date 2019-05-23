using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class SubCategory_model
    {
        public int SubCategoryID { get; set; }
        [Required]
        public string SubCategoryName { get; set; }
        public string SubCategoryDescription { get; set; }
        public int CategoryID { get; set; }
    }
}