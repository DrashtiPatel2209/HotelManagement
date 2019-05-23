using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class HotelFoodService_model
    {
        public int FoodServiceID { get; set; }
        public int HotelID { get; set; }
        public string Name { get; set; }
    }
}