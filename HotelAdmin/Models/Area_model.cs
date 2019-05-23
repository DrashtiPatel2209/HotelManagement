using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class Area_model
    {
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public int CityID { get; set; }

    }
}