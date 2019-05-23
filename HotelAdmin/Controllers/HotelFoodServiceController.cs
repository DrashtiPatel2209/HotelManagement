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
    public class HotelFoodServiceController : Controller
    {
        //
        // GET: /HotelFoodService/

        DataClasses1DataContext db = new DataClasses1DataContext();
          [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["HotelId"]);
        return View(db.HotelFoodServices.Where(x => x.HotelID == id).ToList());
        }
           [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]

        public ActionResult HotelFoodService()
         {  
            
            return View();
            }  
        [HttpPost]
        public ActionResult HotelFoodService(HotelFoodService_model cat)
            {
        HotelFoodService tblcat = new HotelFoodService();
        tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
        tblcat.Name = cat.Name;
        db.HotelFoodServices.InsertOnSubmit(tblcat);
       
        db.SubmitChanges();
        return View();
        }
           [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Edit(int id)
    {
        HotelFoodService_model cat = db.HotelFoodServices.Where(x =>x.FoodServiceID == id).Select(x =>new HotelFoodService_model()
          {
            FoodServiceID = x.FoodServiceID,
            HotelID = x.HotelID,
                Name = x.Name
            }).SingleOrDefault();
        return View(cat);
        }

            [HttpPost]
        public ActionResult Edit(HotelFoodService_model cat)
        {
            HotelFoodService tblcat = db.HotelFoodServices.Where(x =>x.FoodServiceID == cat.FoodServiceID).Single<HotelFoodService>();
            tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
            tblcat.Name = cat.Name;
            db.SubmitChanges();
            return View();
            }
           [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Delete(Int16 id)
        {
            HotelFoodService cat = db.HotelFoodServices.Where(x => x.FoodServiceID == id).Single<HotelFoodService>();
            db.HotelFoodServices.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
      
    
    }
}

