﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelAdmin.Controllers
{
    public class HotelsController : Controller
    {
        //
        // GET: /Hotels/

        public ActionResult Index()
        {
            return View();
        }

    }
}
