using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAdmin.Models;
using HotelAdmin.DBML;
using HotelAdmin.Filters;


namespace HotelAdmin.Controllers
{
        public class HotelRoomController : Controller
        {
            //
            // GET: /HotelRoom/
        DataClasses1DataContext db = new DataClasses1DataContext();
            [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["HotelId"]);
            return View(db.HotelRooms.Where(x => x.HotelID == id).ToList());
        }

             [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult HotelRoom()
        {
          
            ViewBag.roomtype = new SelectList(db.MasterRoomTypes, "RoomTypeID", "RoomTypeName");
            return View();
        }
        [HttpPost]
        public ActionResult HotelRoom(HotelRoom_Model cat)
        {
            HotelRoom tblcat = new HotelRoom();

            tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
            tblcat.RoomTypeID = cat.RoomTypeID;
            tblcat.NumberOfRoom = cat.NumberOfRoom;
            ViewBag.roomtype = new SelectList(db.MasterRoomTypes, "RoomTypeID", "RoomTypeName");
            db.HotelRooms.InsertOnSubmit(tblcat);
           
            db.SubmitChanges();
            return View();
        }
             [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Edit(int id)
        {
            ViewBag.roomtype = new SelectList(db.MasterRoomTypes, "RoomTypeID", "RoomTypeName");
            HotelRoom_Model cat = db.HotelRooms.Where(x => x.HotelRoomID == id).Select(x =>new HotelRoom_Model()
            {
                HotelRoomID = x.HotelRoomID,
                HotelID = x.HotelID,
                RoomTypeID = x.RoomTypeID,
                NumberOfRoom = x.NumberOfRoom
            }).SingleOrDefault();
        return View(cat);
        }
        [HttpPost]
        public ActionResult Edit(HotelRoom_Model cat)
        {
            ViewBag.roomtype = new SelectList(db.MasterRoomTypes, "RoomTypeID", "RoomTypeName");
            HotelRoom tblcat = db.HotelRooms.Where(x => x.HotelRoomID == cat.HotelRoomID).Single<HotelRoom>();
            tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
            tblcat.RoomTypeID = cat.RoomTypeID;
            tblcat.NumberOfRoom = cat.NumberOfRoom;
            db.SubmitChanges();
            return View();

        }
             [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Delete(Int16 id)
        {
            HotelRoom cat = db.HotelRooms.Where(x => x.HotelRoomID == id).Single<HotelRoom>();
            db.HotelRooms.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
       

    }
}
