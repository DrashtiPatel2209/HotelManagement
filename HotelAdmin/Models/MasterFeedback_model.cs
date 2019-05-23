using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class MasterFeedback_model
    {
        public int FeedbackID { get; set; }
        [Required]
        public int UserID { get; set; }
        public string FeedbackDescription { get; set; }
    }
}