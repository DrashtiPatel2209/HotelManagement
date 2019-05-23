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
    public class ComplainController : Controller
    {
        //
        // GET: /Complain/
        DataClasses1DataContext db = new DataClasses1DataContext();
         [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")]
        public ActionResult Index()
        {
            return View(db.MasterComplains.ToList());
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Complain()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Complain(MasterComplain_model cat)
        {
            MasterComplain tblcat = new MasterComplain();
            tblcat.UserID = cat.UserID;
            tblcat.ComplainSubject = cat.ComplainSubject;
            tblcat.ComplainDescription = cat.ComplainDescription;
            tblcat.Reply = cat.Reply;
            db.MasterComplains.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Edit(int id)
        {
            MasterComplain_model cat = db.MasterComplains.Where(x => x.ComplainID == id).Select(x => new MasterComplain_model()
           {
             ComplainID = x.ComplainID,
             UserID = x.UserID,
             ComplainSubject =x.ComplainSubject,
             ComplainDescription = x.ComplainDescription,
             Reply = x.Reply

        }).SingleOrDefault();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(MasterComplain_model cat)
        {
            MasterComplain tblcat = db.MasterComplains.Where(x => x.ComplainID == cat.ComplainID).Single<MasterComplain>();
            tblcat.ComplainID = cat.ComplainID;
            tblcat.ComplainDescription = cat.ComplainDescription;
            tblcat.UserID = cat.UserID;
            tblcat.ComplainSubject = cat.ComplainSubject;
            db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Admin(LoginPage = "~/Admin/Login")] 
        public ActionResult Delete(Int16 id)
        {
            MasterComplain cat = db.MasterComplains.Where(x => x.ComplainID == id).Single<MasterComplain>();
            db.MasterComplains.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

      

    }
}
