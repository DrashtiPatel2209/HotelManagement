using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelAdmin.Models
{
    public class UserPackage_Model
    {
        public int UserPackageID { get; set; }
        public int HotelID { get; set; }
        public int PackageID { get; set; }
        public int UserID { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        

  }
}