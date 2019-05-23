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
    public class Default1Controller : Controller
    {
        //
        // GET: /Default1/
        DataClasses1DataContext db = new DataClasses1DataContext();
         [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Index()
        {
            return View(db.MasterCategories.ToList());
        }
         [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult category()
        {
            return View();
        }


        [HttpPost]
        public ActionResult category(MasterCategory_model cat)
        {
            MasterCategory tblcat = new MasterCategory();
            tblcat.CategoryName = cat.CategoryName;
            tblcat.CategoryDescription = cat.CategoryDescription;
            db.MasterCategories.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }
         [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Edit(int id)
        {
            MasterCategory_model cat = db.MasterCategories.Where(x => x.CategoryId == id).Select(x => new MasterCategory_model()
            {   
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription
                 
            }).SingleOrDefault();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(MasterCategory_model cat)
        {
            MasterCategory tblcat = db.MasterCategories.Where(x=>x.CategoryId == cat.CategoryId).Single<MasterCategory>();
            tblcat.CategoryName = cat.CategoryName;
            tblcat.CategoryDescription = cat.CategoryDescription;
            tblcat.CategoryId = cat.CategoryId;
            db.SubmitChanges();
            return View();
        }
         [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Delete(Int16 id)
        {
            MasterCategory cat = db.MasterCategories.Where(x => x.CategoryId == id).Single<MasterCategory>();
            db.MasterCategories.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

    }
}
