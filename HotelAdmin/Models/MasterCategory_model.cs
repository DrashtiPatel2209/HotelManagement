using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class MasterCategory_model
    {
        public int CategoryId {get; set; }
        [Required]
        public string CategoryName{get; set;}
        public string CategoryDescription{get; set;}

    }
}