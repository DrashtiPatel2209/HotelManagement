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
    public class RoomTypeController : Controller
    {
        //
        // GET: /RoomType/
        DataClasses1DataContext db = new DataClasses1DataContext();
          [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")]
        public ActionResult Index()
        {
            return View(db.MasterRoomTypes.ToList());
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult RoomType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RoomType(MasterRoomType_model cat)
        {
            MasterRoomType tblcat = new MasterRoomType();
            tblcat.RoomTypeName = cat.RoomTypeName;
            tblcat.RoomTypeDescription = cat.RoomTypeDescription;
            tblcat.Price = cat.Price;
            db.MasterRoomTypes.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Edit(int id)
        {
            MasterRoomType_model cat = db.MasterRoomTypes.Where(x => x.RoomTypeID == id).Select(x => new MasterRoomType_model()
               {
                   RoomTypeID=x.RoomTypeID,
                   RoomTypeName=x.RoomTypeName,
                   RoomTypeDescription=x.RoomTypeDescription,
                   Price=x.Price
               }).SingleOrDefault();
                
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(MasterRoomType_model cat)
        {
            MasterRoomType tblcat = db.MasterRoomTypes.Where(x => x.RoomTypeID == cat.RoomTypeID).Single<MasterRoomType>();
            tblcat.RoomTypeID = cat.RoomTypeID;
            tblcat.RoomTypeName = cat.RoomTypeName;
            tblcat.RoomTypeDescription = cat.RoomTypeDescription;
            tblcat.Price = cat.Price;
            db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Delete(Int16 id)
        {
            MasterRoomType cat = db.MasterRoomTypes.Where(x => x.RoomTypeID == id).Single<MasterRoomType>();
            db.MasterRoomTypes.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        



    }
}
