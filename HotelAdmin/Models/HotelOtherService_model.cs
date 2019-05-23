using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class HotelOtherService_model
    {
        public int OtherServiceID { get; set; }
        public int HotelID { get; set; }
        public string TexiService { get; set; }
        public string PickupPlace { get; set; }
        public string DestinationPlace { get; set; }
        public string VehicleType { get; set; }
    }
}