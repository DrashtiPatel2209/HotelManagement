using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class MasterRoomType_model
    {
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; }
        public string RoomTypeDescription { get; set; }
        public int Price { get; set; }
    }
}