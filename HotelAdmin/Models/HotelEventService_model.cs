using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class HotelEventService_model
    {
        public int EventServiceID { get; set; }
        public int HotelID { get; set; }
        public string EventName { get; set; }
    }

}