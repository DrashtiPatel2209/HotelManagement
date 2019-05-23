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
    public class HotelServiceController : Controller
    {
        //
        // GET: /HotelService/
        DataClasses1DataContext db = new DataClasses1DataContext();
        [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["HotelId"]);
            return View(db.HotelServices.Where(x => x.HotelID == id).ToList());
        }


        [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult HotelService()
        {

            return View();
        }
        [HttpPost]
        public ActionResult HotelService(HotelService_model cat)
        {
            HotelService tblcat = new HotelService();
            tblcat.HotelServiceID = cat.HotelServiceID;
            tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
            tblcat.ServiceName = cat.ServiceName;
            db.HotelServices.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Edit(int id)
        {
            HotelService_model cat = db.HotelServices.Where(x => x.HotelServiceID == id).Select(x => new HotelService_model()
            {
                HotelServiceID = x.HotelServiceID,
                HotelID = x.HotelID,
                ServiceName = x.ServiceName,
               
            }).SingleOrDefault();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(HotelService_model cat)
        {
            HotelService tblcat = db.HotelServices.Where(x => x.HotelServiceID == cat.HotelServiceID).Single<HotelService>();
            tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
            tblcat.ServiceName = cat.ServiceName;
            db.SubmitChanges();
            return View();
        }

        [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Delete(Int16 id)
        {
            HotelService cat = db.HotelServices.Where(x => x.HotelServiceID == id).Single<HotelService>();
            db.HotelServices.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
       


    }
}

