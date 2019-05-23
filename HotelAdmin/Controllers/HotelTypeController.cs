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
    public class HotelTypeController : Controller
    {
        //
        // GET: /HotelType/
        DataClasses1DataContext db = new DataClasses1DataContext();
          [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")]

        public ActionResult Index()
        {
            return View(db.MasterHotelTypes.ToList());
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult HotelType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HotelType(MasterHotelType_model cat)
        {
            MasterHotelType tblcat = new MasterHotelType();
            tblcat.Name = cat.Name;
            tblcat.Description = cat.Description;
            db.MasterHotelTypes.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Edit(int id)
        {
            
            MasterHotelType_model cat = db.MasterHotelTypes.Where(x => x.HotelTypeId == id).Select(x => new MasterHotelType_model()
            {
                HotelTypeID=x.HotelTypeId,
                Name=x.Name,
                Description=x.Description

            }).SingleOrDefault();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(MasterHotelType_model cat)
        {
            MasterHotelType tblcat = db.MasterHotelTypes.Where(x => x.HotelTypeId == cat.HotelTypeID).Single<MasterHotelType>();
            tblcat.HotelTypeId = cat.HotelTypeID;
            tblcat.Description = cat.Description;
            tblcat.Name = cat.Name;
            db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Delete(Int16 id)
        {
            MasterHotelType cat = db.MasterHotelTypes.Where(x => x.HotelTypeId == id).Single<MasterHotelType>();
            db.MasterHotelTypes.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
      
    }
}
