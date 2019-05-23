using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAdmin.Models;
using HotelAdmin.DBML;

namespace HotelAdmin.Controllers
{
    public class UserLoginController : Controller
    {
        //
        // GET: /UserLogin/
        DataClasses1DataContext db = new DataClasses1DataContext();
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserRegistration_model re)
        {
            UserRegistration_model rem = db.UserRegistrations.Where(x => x.UserName == re.UserName).Where(x => x.Password == re.Password).Select(x => new UserRegistration_model()
            {
                UserName = x.UserName,
                Password = x.Password
            }).SingleOrDefault();
            if (rem != null)
            {
                return RedirectToAction("Index", "Hotel");
            }
            else
            {
                return View();
            }
        }

    }
}
