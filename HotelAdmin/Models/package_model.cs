using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class package_model
    {
        public int PackageID { get; set; }
        public int HotelID { get; set; }
        public string PackageName { get; set; }
        public string packageDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Amount { get; set; }

    }
}