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
    public class AreaController : Controller
    {
        //
        // GET: /Area/
        DataClasses1DataContext db = new DataClasses1DataContext();
            [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Index()
        {
            return View(db.Areas.ToList());
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Area()
        {
            ViewBag.city = new SelectList(db.Cities,"CityID" ,"CityName");
            return View();
        }
        [HttpPost]
        public ActionResult Area(Area_model cat)
        {
            Area tblcat = new Area();
            tblcat.AreaName = cat.AreaName;
            tblcat.AreaDescription = cat.AreaDescription;
            tblcat.CityID = cat.CityID;
            db.Areas.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            ViewBag.city = new SelectList(db.Cities, "CityID", "CityName");
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Edit(int id)
        {
            Area_model cat = db.Areas.Where(x => x.AreaID == id).Select(x => new Area_model()
            {
                CityID = x.CityID,
                AreaID = x.AreaID,
                AreaName = x.AreaName,
                AreaDescription = x.AreaDescription
            }).SingleOrDefault();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(Area_model cat)
        {
            Area tblcat = db.Areas.Where(x => x.AreaID == cat.AreaID).Single<Area>();
            tblcat.AreaID = cat.AreaID;
            tblcat.CityID = cat.CityID;
            tblcat.AreaName = cat.AreaName;
            tblcat.AreaDescription = cat.AreaDescription;
             db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Delete(Int16 id)
        {
            Area cat = db.Areas.Where(x => x.AreaID == id).Single<Area>();
            db.Areas.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
      
    }
    }

