using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAdmin.Models;
using HotelAdmin.DBML;
using HotelAdmin.Filters;
    public class FeedbackController : Controller
    {
        //
        // GET: /Feedback/
        DataClasses1DataContext db = new DataClasses1DataContext();
         [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")]
        public ActionResult Index()
        {
            return View(db.MasterFeedbacks.ToList());
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FeedBack(MasterFeedback_model cat)
        {
            MasterFeedback tblcat = new MasterFeedback();
            tblcat.UserID = cat.UserID;
            tblcat.FeedbackDescription = cat.FeedbackDescription;
            db.MasterFeedbacks.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Edit(int id)
        {
            MasterFeedback_model cat = db.MasterFeedbacks.Where(x => x.FeedbackID == id).Select(x => new MasterFeedback_model()
            {
                FeedbackID = x.FeedbackID,
                UserID = x.UserID,      
                FeedbackDescription = x.FeedbackDescription
            }).SingleOrDefault();
            return View(cat);
        }
        [HttpPost]
        public ActionResult Edit(MasterFeedback_model cat)
        {
            MasterFeedback tblcat = db.MasterFeedbacks.Where(x => x.FeedbackID == cat.FeedbackID).Single<MasterFeedback>();
            tblcat.FeedbackID = cat.FeedbackID;
            tblcat.FeedbackDescription = cat.FeedbackDescription;
            tblcat.UserID = cat.UserID;
            db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Delete(Int16 id)
        {
            MasterFeedback cat = db.MasterFeedbacks.Where(x => x.FeedbackID == id).Single<MasterFeedback>();
            db.MasterFeedbacks.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
       

    }

