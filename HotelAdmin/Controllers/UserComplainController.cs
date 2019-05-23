using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAdmin.Models;
using HotelAdmin.DBML;


namespace HotelAdmin.Controllers
{
    public class UserComplainController : Controller
    {
        //
        // GET: /UserComplain/
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Index(MasterComplain_model cat)
        {
            MasterComplain tblcat = new MasterComplain();
            tblcat.ComplainSubject  = cat.ComplainSubject;
            tblcat.ComplainDescription = cat.ComplainDescription;
            db.MasterComplains.InsertOnSubmit(tblcat);
            db.SubmitChanges();
            return View();
        }
        
    }
}
