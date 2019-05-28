using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class MasterHotelRegistration_model
    {
        public int HotelID { get; set; }
        public string HotelName { get; set; }
        public int HotelTypeID { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string photo { get; set; }


    }
}