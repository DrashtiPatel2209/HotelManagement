using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelAdmin.Models;
using HotelAdmin.DBML;
using System.Linq;
using HotelAdmin;
using HotelAdmin.ViewModel;

namespace HotelAdminTestProject
{
    [TestClass]
    public class HotelAdminTest
    {
        [TestMethod]
        public void HotelAdminLogIn()
        {
            var loginModel = new Login_Model();
            loginModel.Email = "algoquin@gmail.com";
            loginModel.password = "algoquin";
            var validation1 = new Validation();
            var LoginTrueOrNot = validation1.CheckWhetherAdminHotelIdOrNot(loginModel);
            Assert.IsTrue(LoginTrueOrNot);
        }

        [TestMethod]
        public void UserLogIn()
        {
            var loginModel = new Login_Model();
            loginModel.Email = "drashti@gmail.com";
            loginModel.password = "12345";
            var validation1 = new Validation();
            var LoginTrueOrNot = validation1.CheckWhetherUserIdOrNot(loginModel);
            Assert.IsTrue(LoginTrueOrNot);
        }

        [TestMethod]
        public void User()
        {
            var loginModel = new Login_Model();
            loginModel.Email = "drashti@gmail.com";
            loginModel.password = "12345";
            var validation1 = new Validation();
            var LoginTrueOrNot = validation1.CheckWhetherUserIdOrNot(loginModel);
            Assert.IsTrue(LoginTrueOrNot);
        }

        [TestMethod]
        public void HotelExistOrNot()
        {
            var hotelReg = new MasterHotelRegistration_model();
            hotelReg.EmailID = "howardJohnson@gmail.com";
            var validation1 = new Validation();
            var hotelEmailisValidOrNot = validation1.invalidEmailID(hotelReg);
            Assert.IsTrue(hotelEmailisValidOrNot);
        }

        //[TestMethod]
        //public void HotelPinCodeValid()
        //{
        //    var hotel_Reg = new MasterHotelRegistration_model();
        //    hotel_Reg.Pincode = "123 456";
        //    char charsToTrim = ' ';
        //    var RegLength = hotel_Reg.Pincode.Trim(charsToTrim);
        //    string reg = RegLength.Replace("  ", "");
        //    Assert.AreSame(reg.Length, 6);
        //}

    }
}
