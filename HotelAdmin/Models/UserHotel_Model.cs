using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class UserHotel_Model
    {
        public int UserHotelID { get; set; }
        public int UserID { get; set; }
        public int HotelID { get; set; }
        public DateTime Checkindate { get; set; }
        public DateTime Checkoutdate { get; set; }
        public int NumberOfAdultPerson { get; set; }
        public int NumberOfChildPerson { get; set; }
        public int RoomTypeID { get; set; }
        public int Amount { get; set; }
        public int NumberOfRooms { get; set; }
    }
}