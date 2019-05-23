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
    public class HotelOtherServiceController : Controller
    {
        //
        // GET: /HotelOther/
        
       DataClasses1DataContext db = new DataClasses1DataContext();
         [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["HotelId"]);
            return View(db.HotelOtherServices.Where(x => x.HotelID == id).ToList());
        }
         [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult HotelOtherService()
        {

            return View();
        }
        [HttpPost]
        public ActionResult HotelOtherService(HotelOtherService_model cat)
        {
            HotelOtherService tblcat = new HotelOtherService();
            tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
            tblcat.TexiService= cat.TexiService;
            
            tblcat.PickupPlace = cat.PickupPlace;
            tblcat.DestinationPlace = cat.DestinationPlace;
            tblcat.VehicleType = cat.VehicleType;
            db.HotelOtherServices.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }
         [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
         public ActionResult Edit(int id)
         {
                HotelOtherService_model cat = db.HotelOtherServices.Where(x => x.OtherServiceID == id).Select(x =>new HotelOtherService_model()
            {
                OtherServiceID = x.OtherServiceID,
                HotelID = x.HotelID,
                TexiService=x.TexiService,
                PickupPlace=x.PickupPlace,
                DestinationPlace=x.DestinationPlace,
                VehicleType=x.VehicleType,
                }).SingleOrDefault();
                return View(cat);
        }

        [HttpPost]
            public ActionResult Edit(HotelOtherService_model cat)
        {
            HotelOtherService tblcat = db.HotelOtherServices.Where(x => x.OtherServiceID == cat.OtherServiceID).Single<HotelOtherService>();
            tblcat.TexiService = cat.TexiService;
            tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
            
            tblcat.PickupPlace = cat.PickupPlace;
            tblcat.DestinationPlace = cat.DestinationPlace;
            tblcat.VehicleType = cat.VehicleType;
            db.SubmitChanges();
            return View();
        }
         [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Delete(Int16 id)
        {
            HotelOtherService cat = db.HotelOtherServices.Where(x => x.OtherServiceID == id).Single<HotelOtherService>();
            db.HotelOtherServices.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
       
    }
}





