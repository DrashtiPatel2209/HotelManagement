using HotelAdmin.DBML;
using HotelAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelAdmin.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        DataClasses1DataContext db = new DataClasses1DataContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login_Model lm)
        {
            if (lm.Email == "Admin@gmail.com" && lm.password == "Admin")
            {
                Session["adminId"] = 1;
                return RedirectToAction("category", "Default1");
            }

                MasterHotelRegistration_model hotl = db.MasterHotelRegistrations.Where(x=>x.EmailID == lm.Email).Where(x=>x.Password == lm.password).Select(x=> new MasterHotelRegistration_model()
                {
                    HotelID = x.HotelID,
                    HotelName = x.HotelName
                }).SingleOrDefault();
                if (hotl != null)
                {
                    Session["HotelId"] = hotl.HotelID;
                    Session["HotelName"] = hotl.HotelName;
                    return RedirectToAction("Edit", "HotelRegistration");
                }
                else
                {
                    ViewBag.Message = "Enter Valid Username Or Password";
                    return View();
                }
        }

     

    }
}
