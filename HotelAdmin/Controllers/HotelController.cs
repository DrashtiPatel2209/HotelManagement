using HotelAdmin.DBML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelAdmin.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/
        DataClasses1DataContext db = new DataClasses1DataContext();

        public ActionResult Index()
        {
            return View(db.MasterHotelRegistrations.OrderByDescending(x=>x.HotelID).Take(4).ToList());
        }

    }
}
