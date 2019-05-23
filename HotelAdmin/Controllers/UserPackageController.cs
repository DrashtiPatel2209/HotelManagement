using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAdmin.Models;
using HotelAdmin.DBML;


namespace HotelAdmin.Controllers
{
    public class UserPackageController : Controller
    {
        //
        // GET: /UserPackage/
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult UserPackage()
        {
            ViewBag.user = new SelectList(db.UserRegistrations, "UserID", "UserName");
            ViewBag.hotel = new SelectList(db.MasterHotelRegistrations, "HotelID", "HotelName");
            ViewBag.package = new SelectList(db.Packages, "PackageID", "PackageName");
            return View();
        }
        [HttpPost]
        public ActionResult UserPackage(UserPackage_Model cat)
        {
            UserPackage tblcat = new UserPackage();
            tblcat.HotelID = cat.HotelID;
            tblcat.PackageID = cat.PackageID;
            tblcat.UserID = cat.UserID;
            tblcat.Amount = cat.Amount;
            tblcat.Date= cat.Date;
            ViewBag.user = new SelectList(db.UserRegistrations, "UserID", "UserName");
            ViewBag.hotel = new SelectList(db.MasterHotelRegistrations, "HotelID", "HotelName");
            ViewBag.package = new SelectList(db.Packages, "PackageID", "PackageName");
            db.UserPackages.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }

    }
}
