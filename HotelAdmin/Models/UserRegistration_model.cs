using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class UserRegistration_model
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserPhoneNumber { get; set; }
        public string UserAddress { get; set; }
        public int CityID { get; set; }
        public int AreaID { get; set; }
        public string UserDOB { get; set; }
        public string Gender { get; set; }
        public string UserOccupation { get; set; }
        public string MaritialStatus { get; set; }
        public string EmailID { get; set; }

    }
}