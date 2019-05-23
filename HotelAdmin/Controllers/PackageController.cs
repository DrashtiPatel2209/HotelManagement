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
        public class packageController : Controller
    {
        //
        // GET: /package/
        DataClasses1DataContext db = new DataClasses1DataContext();
              [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
       public ActionResult index()
        {
            int id = Convert.ToInt32(Session["HotelId"]);
            return View(db.Packages.Where(x => x.HotelID == id).ToList());
        }
              [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Package()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Package(package_model cat)
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

            Package tblcat = new Package();
            tblcat.PackageID = cat.PackageID;
            tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
            tblcat.PackageName = cat.PackageName;
            tblcat.PackageDescription = cat.packageDescription;
            tblcat.StartDate = cat.StartDate;
            tblcat.EndDate = cat.EndDate;
            tblcat.Amount = cat.Amount;
            tblcat.photo = file.FileName;
            db.Packages.InsertOnSubmit(tblcat);
           
            db.SubmitChanges();
            
            return View();
        }
              [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Edit(int id)
        {
        package_model cat = db.Packages.Where(x => x.PackageID == id).Select(x =>new package_model()
            {
                PackageID = x.PackageID,
                HotelID = x.HotelID,
                PackageName = x.PackageName,
                packageDescription = x.PackageDescription,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Amount = x.Amount
            }).SingleOrDefault();
                return View(cat);
        }

        [HttpPost]
         public ActionResult Edit(package_model cat)
        {
            Package tblcat = db.Packages.Where(x => x.PackageID == cat.PackageID).Single<Package>();
            tblcat.HotelID = Convert.ToInt32(Session["HotelId"]);
            tblcat.PackageName = cat.PackageName;
            tblcat.PackageDescription = cat.packageDescription;
            tblcat.StartDate = cat.StartDate;
            tblcat.EndDate = cat.EndDate;
            tblcat.Amount = cat.Amount;
            db.SubmitChanges();
            return View();
        }
              [CustomAuthorization_Hotel(LoginPage = "~/Admin/Login")]
        public ActionResult Delete(Int16 id)
        {
            Package cat = db.Packages.Where(x => x.PackageID == id).Single<Package>();
            db.Packages.DeleteOnSubmit(cat);
            db.SubmitChanges();
            return RedirectToAction("index");
        }
       

    }
}

