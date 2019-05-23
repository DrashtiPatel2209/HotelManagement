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
    public class SubCategoryController : Controller
    {
        //
        // GET: /SubCategory/
        DataClasses1DataContext db = new DataClasses1DataContext();
            [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Index()
        {
            return View(db.SubCategories.ToList());
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult SubCategory()
        {
            ViewBag.cat = new SelectList(db.MasterCategories, "CategoryID", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult SubCategory(SubCategory_model cat)
        {
            SubCategory tblcat = new SubCategory();
            tblcat.SubcategoryName = cat.SubCategoryName;
            tblcat.SubcategoryDescription = cat.SubCategoryDescription;
            tblcat.CategoryID = cat.CategoryID;
            db.SubCategories.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            ViewBag.cat = new SelectList(db.MasterCategories, "CategoryID", "CategoryName");
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Edit(int id)
        {
            SubCategory_model cat = db.SubCategories.Where(x => x.SubcategoryID == id).Select(x => new SubCategory_model()
            {
                CategoryID = x.CategoryID,
                SubCategoryID = x.SubcategoryID,
                SubCategoryName = x.SubcategoryName,
                SubCategoryDescription = x.SubcategoryDescription
            }).SingleOrDefault();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(SubCategory_model cat)
        {
            SubCategory tblcat = db.SubCategories.Where(x => x.SubcategoryID == cat.SubCategoryID).Single<SubCategory>();
            tblcat.CategoryID = cat.CategoryID;
            tblcat.SubcategoryID = cat.SubCategoryID;
            tblcat.SubcategoryDescription = cat.SubCategoryDescription;
            tblcat.SubcategoryName = cat.SubCategoryName;
            db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Delete(Int16 id)
        {
            SubCategory cat = db.SubCategories.Where(x => x.SubcategoryID == id).Single<SubCategory>();
            db.SubCategories.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
       

    }
}
