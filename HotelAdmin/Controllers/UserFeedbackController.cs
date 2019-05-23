using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAdmin.Models;
using HotelAdmin.DBML;

namespace HotelAdmin.Controllers
{
    public class UserFeedbackController : Controller
    {
        //
        // GET: /UserFeedback/
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(MasterFeedback_model cat)
        {
            MasterFeedback tblcat = new MasterFeedback();
            tblcat.UserID = cat.UserID;
            tblcat.FeedbackDescription = cat.FeedbackDescription;
            db.MasterFeedbacks.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }

    }
}
