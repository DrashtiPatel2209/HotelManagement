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
    public class HotelEventServiceController : Controller
    {
        //  
        // GET: /HotelEventService/
        DataClasses1DataContext db = new DataClasses1DataContext();
         [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["HotelId"]);
            return View(db.HotelEventServices.Where(x => x.HotelID == id).ToList());

        }
         [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
         public ActionResult HotelEventService()
        {

            return View();
        }
        [HttpPost]
        public ActionResult HotelEventService(HotelEventService_model cat)
        {
        HotelEventService tblcat = new HotelEventService();
        tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
        tblcat.EventName = cat.EventName;
       
        db.HotelEventServices.InsertOnSubmit(tblcat);
  
        db.SubmitChanges();
        return View();
        }
         [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
    public ActionResult Edit(int id)
        {
    HotelEventService_model cat = db.HotelEventServices.Where(x =>x.EventServiceID == id).Select(x =>new HotelEventService_model() 
    {
         EventServiceID = x.EventServiceID,
        HotelID = x.HotelID,
         EventName = x.EventName
        }).SingleOrDefault();
        return View(cat);
        }
    
        [HttpPost]
        public ActionResult Edit(HotelEventService_model cat)
        {       
        HotelEventService tblcat = db.HotelEventServices.Where(x =>x.EventServiceID == cat.EventServiceID).Single<HotelEventService>();
        tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
        tblcat.EventName = cat.EventName;
        db.SubmitChanges();
        return View();
        }
         [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Delete(Int16 id)
        {
            HotelEventService cat = db.HotelEventServices.Where(x => x.EventServiceID == id).Single<HotelEventService>();
            db.HotelEventServices.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
            }
       

    }
    }

















