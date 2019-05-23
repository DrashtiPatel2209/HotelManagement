using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAdmin.Models;
using HotelAdmin.DBML;
using HotelAdmin.Filters;

    public class CityController : Controller
    {
        //
        // GET: /City/
        
        DataClasses1DataContext db = new DataClasses1DataContext();
        [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Index()
        {
            return View(db.Cities.ToList());
        }
        [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult City()
        {
            return View();
        }
        [HttpPost]
     public ActionResult City(City_model cat)
        {
            
            City tblcat = new City();
            tblcat.CityName = cat.CityName;
            tblcat.CityDescription = cat.CityDescription;
            db.Cities.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }
           [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Edit(int id)
        {
            City_model cat = db.Cities.Where(x => x.CityID == id).Select(x => new City_model()
            {
                CityID = x.CityID,
                CityName = x.CityName,
                CityDescription  = x.CityDescription
            }).SingleOrDefault();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(City_model cat)
        {
            City tblcat = db.Cities.Where(x => x.CityID == cat.CityID).Single<City>();
            tblcat.CityName = cat.CityName;
            tblcat.CityDescription = cat.CityDescription;
            tblcat.CityID = cat.CityID;
            db.SubmitChanges();
            return View();
        }
           [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Delete(Int16 id)
        {
            City cat = db.Cities.Where(x => x.CityID == id).Single<City>();
            db.Cities.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
      

    }
 
