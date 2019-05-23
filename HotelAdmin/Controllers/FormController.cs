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
    public class FormController : Controller
    {
        //
        // GET: /form/
        DataClasses1DataContext db = new DataClasses1DataContext();
          [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Index1()
        {
            
            return View(db.UserRegistrations.ToList());
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Index()
        {

            return View();
        }
       
        [HttpPost]
        public ActionResult Index(UserRegistration_model cat)
        {
            UserRegistration tblcat = new UserRegistration();
            tblcat.UserName  = cat.UserName;
            tblcat.Password = cat.Password;
            tblcat.UserPhoneNumber = cat.UserPhoneNumber;
            tblcat.UserID = cat.UserID;
            tblcat.UserAddress = cat.UserAddress;
            tblcat.CityID = cat.CityID;
            tblcat.AreaID = cat.AreaID;
            tblcat.UserDOB = cat.UserDOB;
            tblcat.Gender = cat.Gender;
            tblcat.UserOccupation = cat.UserOccupation;
            tblcat.Maritial_Status = cat.MaritialStatus;
            tblcat.Email_id = cat.EmailID;
            db.UserRegistrations.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
         public ActionResult Edit(int id)
        {
            UserRegistration_model cat = db.UserRegistrations.Where(x => x.UserID == id).Select(x => new UserRegistration_model()
            {   
                UserName  = x.UserName,
                Password = x.Password,
                UserPhoneNumber = x.UserPhoneNumber,
                UserAddress = x.UserAddress,
               CityID = x.CityID,
               AreaID = x.AreaID,
               UserDOB = x.UserDOB,
                Gender = x.Gender,
               UserOccupation = x.UserOccupation,
               MaritialStatus = x.Maritial_Status,
               EmailID = x.Email_id
            }).SingleOrDefault();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(UserRegistration_model cat)
        {
            UserRegistration tblcat = db.UserRegistrations.Where(x => x.UserID == cat.UserID).Single<UserRegistration>();
            tblcat.UserName  = cat.UserName;
            tblcat.Password = cat.Password;
            tblcat.UserPhoneNumber = cat.UserPhoneNumber;
             tblcat.UserAddress = cat.UserAddress;
             tblcat.CityID = cat.CityID;
            tblcat.AreaID = cat.AreaID;
           tblcat.UserDOB = cat.UserDOB;
           tblcat.Gender = cat.Gender;
             tblcat.UserOccupation = cat.UserOccupation;
             tblcat.Maritial_Status = cat.MaritialStatus;
            tblcat.Email_id = cat.EmailID;
           db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Delete(Int16 id)
        {
            UserRegistration cat = db.UserRegistrations.Where(x => x.UserID == id).Single<UserRegistration>();
            db.UserRegistrations.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index1");
        }
       
       
    }
    }

   
