using HotelAdmin.DBML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelAdmin.Models;

namespace HotelAdmin.ViewModel
{
    public class Validation
    {
        DataClasses1DataContext db = new DataClasses1DataContext("Data Source = HP-PC; Initial Catalog = DBHotel; Integrated Security = True");
        public bool CheckWhetherAdminHotelIdOrNot(Login_Model lm)
        {
            if (lm.Email == "Admin@gmail.com" && lm.password == "Admin")
            {
                return true;
            }
            MasterHotelRegistration_model hotl = db.MasterHotelRegistrations.Where(x => x.EmailID == lm.Email).Where(x => x.Password == lm.password).Select(x => new MasterHotelRegistration_model()
            {
                HotelID = x.HotelID,
                HotelName = x.HotelName
            }).FirstOrDefault();
            if (hotl != null)
            {
                return true;
            }
            return false;

        }

        public bool CheckWhetherUserIdOrNot(Login_Model lm)
        {
            
            UserRegistration_model user = db.UserRegistrations.Where(x => x.UserName == lm.Email).Where(x => x.Password == lm.password).Select(x => new UserRegistration_model()
            {
                UserID = x.UserID,
                UserName = x.UserName
            }).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            return false;

        }

        public bool invalidEmailID(MasterHotelRegistration_model mstHotelReg)
        {

            MasterHotelRegistration_model hotl = db.MasterHotelRegistrations.Where(x => x.EmailID.ToLower() == mstHotelReg.EmailID.ToLower()).Select(x => new MasterHotelRegistration_model()
            {
                HotelID = x.HotelID,
                HotelName = x.HotelName
            }).FirstOrDefault();
            if (hotl == null)
            {
                return true;
            }

            return false;
        }

       

    }
}