using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAdmin.Models;
using HotelAdmin.DBML;

namespace HotelAdmin.Controllers
{
    public class UserHotelController : Controller
    {
        //
        // GET: /UserHotel/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult UserHotel()
        {
            ViewBag.user = new SelectList(db.UserRegistrations, "UserID", "UserName");
            ViewBag.hotel = new SelectList(db.MasterHotelRegistrations, "HotelID", "HotelName");
            ViewBag.roomtype = new SelectList(db.MasterRoomTypes, "RoomtypeID", "RoomtypeName");
            return View();
        }
        [HttpPost]
        public ActionResult UserHotel(UserHotel_Model cat)
        {
            UserHotel tblcat = new UserHotel();
            tblcat.UserID = cat.UserID;
            tblcat.HotelID = cat.HotelID;
            tblcat.Checkindate = cat.Checkindate;
            tblcat.Checkoutdate = cat.Checkoutdate;
            tblcat.NumberOfAdultPerson = cat.NumberOfAdultPerson;
            tblcat.NumberOfChildPerson = cat.NumberOfChildPerson;
            tblcat.RoomTypeID = cat.RoomTypeID;
            tblcat.Amount = cat.Amount;
            tblcat.NumberOfRooms = cat.NumberOfRooms;
            ViewBag.user = new SelectList(db.UserRegistrations, "UserID", "UserName");
            ViewBag.hotel = new SelectList(db.MasterHotelRegistrations, "HotelID", "HotelName");
            ViewBag.roomtype = new SelectList(db.MasterRoomTypes, "RoomtypeID", "RoomtypeName");
            db.UserHotels.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }

    }
}
