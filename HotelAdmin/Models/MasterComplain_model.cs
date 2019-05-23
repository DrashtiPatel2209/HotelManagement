using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class MasterComplain_model
    {
        public int ComplainID { get; set; }
        public int UserID { get; set; }
        public string ComplainSubject { get; set; }
        public string ComplainDescription { get; set; }
        public string Reply { get; set; }



    }
}