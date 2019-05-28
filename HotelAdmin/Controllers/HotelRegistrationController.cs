using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAdmin.Models;
using HotelAdmin.DBML;
using HotelAdmin.Filters;
using System.IO;


namespace HotelAdmin.Controllers
{
    public class HotelRegistrationController : Controller
    {
        //
        // GET: /HotelRegistration/

        DataClasses1DataContext db = new DataClasses1DataContext();
        [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")] 

        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["HotelId"]);
            return View(db.MasterHotelRegistrations.Where(x => x.HotelID == id).ToList());
        }
        public ActionResult HotelRegistration()
        {
            ViewBag.HotelType = new SelectList(db.MasterHotelTypes, "HotelTypeID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult HotelRegistration(MasterHotelRegistration_model cat)
        {
            HttpPostedFileBase file = Request.Files["file1"];
            if (file.FileName == null || file.FileName == "")
            {
                ModelState.AddModelError("File", "Please Upload Your file");
            }
            else if (file.ContentLength > 0)
            {
                int MaxContentLenght = 1024 * 1024 * 3; // 3 Mb Size of photos
                string[] AllowFileExtension = new string[] { ".jpg", ".jpeg", ".png", ".JPG", ".JPEG", ".PNG" };
                if (AllowFileExtension.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    var filename = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/FileUpload"), filename);
                    file.SaveAs(path);
                }
                else if (file.ContentLength > MaxContentLenght)
                {
                    ModelState.AddModelError("File", "your file is so large, please upload maximum size of" + MaxContentLenght + "MB");

                }
                else
                {
                    ModelState.AddModelError("File", "Please upolad file type like" + string.Join(", ", AllowFileExtension));
                }
            }
            else
            {

            }

            MasterHotelRegistration tblcat = new MasterHotelRegistration();
            tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
            tblcat.HotelName = cat.HotelName;
            tblcat.HotelTypeID = cat.HotelTypeID;
            tblcat.Address = cat.Address;
            tblcat.Pincode = cat.Pincode;
            tblcat.EmailID = cat.EmailID;
            tblcat.Password = cat.Password;
            tblcat.photo = file.FileName;
            db.MasterHotelRegistrations.InsertOnSubmit(tblcat);
            ViewBag.HotelType = new SelectList(db.MasterHotelTypes, "HotelTypeID", "Name");
            db.SubmitChanges();
            return View();
        }
        [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")] 
        public ActionResult Edit()
        {
            ViewBag.hoteltype = new SelectList(db.MasterHotelTypes, "HotelTypeID", "HotelTypeName");
            int id = Convert.ToInt32(Session["HotelId"]);
            MasterHotelRegistration_model cat = db.MasterHotelRegistrations.Where(x => x.HotelID == id).Select(x =>new MasterHotelRegistration_model()
            {

                HotelTypeID = x.HotelTypeID,
                Address = x.Address,
                Pincode=x.Pincode,
                EmailID = x.EmailID,
                Password=x.Password
            }).SingleOrDefault();
            return View(cat);
        }

        [HttpPost]
        public ActionResult Edit(MasterHotelRegistration_model cat)
        {

            int id = Convert.ToInt32(Session["HotelId"]);
            MasterHotelRegistration tblcat = db.MasterHotelRegistrations.Where(x => x.HotelID == id).Single<MasterHotelRegistration>();
            tblcat.HotelID = id;
            tblcat.HotelName = cat.HotelName;
            tblcat.HotelTypeID = cat.HotelTypeID;
            tblcat.Address = cat.Address;
            tblcat.Pincode = cat.Pincode;
            tblcat.EmailID = cat.EmailID;
            tblcat.Password = cat.Password;
            db.SubmitChanges();
            return View();
        }
        [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")] 
        public ActionResult Delete(Int16 id)
        {
        
            MasterHotelRegistration cat = db.MasterHotelRegistrations.Where(x => x.HotelID == id).Single<MasterHotelRegistration>();
            db.MasterHotelRegistrations.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
      

    }
}





