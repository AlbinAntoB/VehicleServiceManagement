/*********************************************************************************************************** * Created by       : Albin Anto * Created On       : 20th Oct 2021 *  * Reviewed By      : Hilda sister * Reviewed On      : 26th Nov 2021 *  ***********************************************************************************************************/
namespace VehicleServiceManagement.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net;
    using System.Net.Mail;
    using VehicleServiceManagement.Data;
    using VehicleServiceManagement.Models;
    using VehicleSeviceManagement.Framework;
    using VehicleSeviceManagement.Framework.Helper;
    public class VehicleController : Controller
    {

        //Injecting a Vehicle repository
        private readonly IVehicleRepository _vehicleRepository;
        /// <summary>
        /// Constructor of Vehicle repository
        /// </summary>
        /// <param name="_vehicleRepository"></param>
        public VehicleController(IVehicleRepository _vehicleRepository)
        {
            this._vehicleRepository = _vehicleRepository;
        }
        // Creating an object for Comman model
        CustomerCommanModel customerCommanModel = new CustomerCommanModel();
        #region Show Registertion
        /// <summary>
        /// To show registerion page
        /// </summary>
        /// <returns></returns>
        public IActionResult Registertion()
        {
            return View();
        }
        #endregion
        #region Index Page
        /// <summary>
        /// To show an index page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            DataValue dv = new DataValue();
            customerCommanModel = _vehicleRepository.FetchCustomerCount(dv);
            customerCommanModel = _vehicleRepository.FetchGst(dv);
            if (customerCommanModel.GstList != null && customerCommanModel.GstList.Count > 0)
            {
                HttpContext.Session.SetString(MessageCatalog.Customer.CustomerProperty.ABOVETHOUSAND, customerCommanModel.GstList[0].AboveThousand.ToString());
                HttpContext.Session.SetString(MessageCatalog.Customer.CustomerProperty.LESSTHOUSAND, customerCommanModel.GstList[0].LessThousand.ToString());
            }
            return View(customerCommanModel);
        }
        #endregion
        #region Check Login 
        /// <summary>
        /// Check username and password if its corrext allow to index page  else stay in Registertion page
        /// </summary>
        /// <param name="customer">By this parameter can get its properties</param>
        /// <returns></returns>
        public IActionResult CheckLogin(CustomerModel customer)
        {
            try
            {
                HttpContext.Session.Clear();
                if (!string.IsNullOrEmpty(customer.Email) && !string.IsNullOrEmpty(customer.Password))
                {
                    CustomerCommanModel customerCommanModel = new CustomerCommanModel();
                    DataValue dv = new DataValue();
                    dv.Add(MessageCatalog.Customer.CustomerProperty.EMAIL, customer.Email, EnumCommand.DataType.Varchar);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.PASSWORD, customer.Password, EnumCommand.DataType.nVarchar);
                    customerCommanModel = _vehicleRepository.CheckUserName(dv);
                    if(customerCommanModel.customermodelList != null && customerCommanModel.customermodelList.Count > 0)
                    {
                        HttpContext.Session.SetInt32(MessageCatalog.Customer.CustomerProperty.USERROLL, customerCommanModel.customermodelList[0].UserRoll);
                        HttpContext.Session.SetInt32(MessageCatalog.Customer.CustomerProperty.CUSTOMERID, customerCommanModel.customermodelList[0].CustomerId);
                        HttpContext.Session.SetString(MessageCatalog.Customer.CustomerProperty.CUSTOMERNAME, customerCommanModel.customermodelList[0].CustomerName);

                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Username And Password is correct!", MessageCatalog.ToastrTypes.Success);

                        return RedirectToAction("Index", customerCommanModel);
                    }
                    else if(customerCommanModel.customermodelList == null)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Invalid username or password!", MessageCatalog.ToastrTypes.Error);
                }

            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return View("Registertion");
        }
        #endregion
        #region Save Registertion Customer Details
        /// <summary>
        ///  Insert an customer Registertion records  into db
        /// </summary>
        /// <param name="customer"> Creating a object for customermodel so that we can access its property</param>
        /// <returns></returns>
        public IActionResult SaveCustomer(CustomerModel customer)
        {
            try
            {
                if (!string.IsNullOrEmpty(customer.CustomerId.ToString()) && !string.IsNullOrEmpty(customer.CustomerName)
                && !string.IsNullOrEmpty(customer.Email) && !string.IsNullOrEmpty(customer.MobileNo) && !string.IsNullOrEmpty(customer.Address)
                && !string.IsNullOrEmpty(customer.Password))
                {
                    ResultArgs result = new ResultArgs();
                    DataValue dv = new DataValue();
                    dv.Add(MessageCatalog.Customer.CustomerProperty.CUSTOMERID, customer.CustomerId, EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.CUSTOMERNAME, customer.CustomerName, EnumCommand.DataType.Varchar);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.EMAIL, customer.Email, EnumCommand.DataType.Varchar);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.MOBILENO, customer.MobileNo, EnumCommand.DataType.Varchar);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.ADDRESS, customer.Address, EnumCommand.DataType.Varchar);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.PASSWORD, customer.Password, EnumCommand.DataType.nVarchar);
                    result = _vehicleRepository.InsertCutomerRegistertion(dv);
                    if (ConversionHelper.ToInt32(result.ReturnValue) == -1)
                        TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Customer Details not Save!", "error");
                    else if (ConversionHelper.ToInt32(result.ReturnValue) == 1)
                        TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Customer Details Saved!", "success");
                }
                else
                    TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Customer details not saved because value is empty!", "error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View("Registertion");
        }
        #endregion
        #region Change password using otp
        /// <summary>
        /// To show forget password page
        /// </summary>
        /// <returns></returns>
        public IActionResult Forgetpassword()
        {
            return View();
        }
        /// <summary>
        /// To check the email id and sent otp to customer
        /// </summary>
        /// <param name="customer">By parameter get an email id</param>
        /// <returns></returns>
        public IActionResult EmailCheck(CustomerModel customer)
        {
            var RandomCode = new Random();
            try
            {
                string emailFromAddress = Settingsconfiguration.Configuration?.SMTPMailConfig?.emailFromAddress.ToString();
                string subject = Settingsconfiguration.Configuration?.SMTPMailConfig?.subject.ToString();
                string SMTPServer = Settingsconfiguration.Configuration?.SMTPMailConfig?.SMTPServer.ToString();
                int SMTPPort = Convert.ToInt32(Settingsconfiguration.Configuration?.SMTPMailConfig?.SMTPPort.ToString());
                string password = Settingsconfiguration.Configuration?.SMTPMailConfig?.password.ToString();
                bool enableSSL = ConversionHelper.ToBoolean(Settingsconfiguration.Configuration?.SMTPMailConfig?.enableSSL);
                string body = Settingsconfiguration.Configuration?.SMTPMailConfig?.body.ToString();
                var otp = RandomCode.Next(0, 999999).ToString("D6");
                HttpContext.Session.SetString(MessageCatalog.Customer.CustomerProperty.OTP, otp);
                HttpContext.Session.SetString(MessageCatalog.Customer.CustomerProperty.EMAIL, customer.Email);
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(customer.Email);
                mail.Subject = subject;
                mail.Body = body + otp;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment
                using (SmtpClient smtp = new SmtpClient(SMTPServer, SMTPPort))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return View("Forgetpassword");
        }
        /// <summary>
        /// To verify the otp is its correct allow to change password or stay in forget password page
        /// </summary>
        /// <param name="OTP"></param>
        /// <returns></returns>
        public IActionResult VerifyOTP(string OTP)
        {
            var Verify = HttpContext.Session.GetString(MessageCatalog.Customer.CustomerProperty.OTP);
            if (Verify == OTP)
            {
                TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "OTP Enterd is correct", MessageCatalog.ToastrTypes.Success);
                return View("Changepassword");
            }
            else
            {
                TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "OTP Enter wrong", MessageCatalog.ToastrTypes.Error);
                return View("ForgetPassword");

            }

        }
        /// <summary>
        /// To show change password page
        /// </summary>
        /// <returns></returns>
        public IActionResult Changepassword()
        {
            return View();
        }
        /// <summary>
        /// This is to change password 
        /// </summary>
        /// <param name="customer">By this is parameter password is get</param>
        /// <returns></returns>
        public IActionResult Changepass(CustomerModel customer)
        {
            try
            {
                ResultArgs result = new ResultArgs();
                DataValue dv = new DataValue();
                dv.Add(MessageCatalog.Customer.CustomerProperty.EMAIL, HttpContext.Session.GetString(MessageCatalog.Customer.CustomerProperty.EMAIL), EnumCommand.DataType.Varchar);
                dv.Add(MessageCatalog.Customer.CustomerProperty.PASSWORD, customer.Password, EnumCommand.DataType.nVarchar);

                result = _vehicleRepository.UpdatePassword(dv);
                if (ConversionHelper.ToInt32(result.ReturnValue) == 1)
                    TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Password Updated Successfully!", MessageCatalog.ToastrTypes.Success);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return View("Registertion");
        }
        #endregion
        #region Save GstPrice
        /// <summary>
        /// To Save Gst Price
        /// </summary>
        /// <param name="gst">By this parameter can get it values from cshtml page</param>
        /// <returns></returns>
        public IActionResult SaveGst(Gst gst)
        {
            try
            {
                if (!string.IsNullOrEmpty(gst.AboveThousand.ToString()) && !string.IsNullOrEmpty(gst.LessThousand.ToString()))
                {
                    ResultArgs result = new ResultArgs();
                    DataValue dv = new DataValue();
                    int GstId = 1;
                    dv.Add(MessageCatalog.Customer.CustomerProperty.GSTID, GstId, EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.ABOVETHOUSAND, gst.AboveThousand, EnumCommand.DataType.Money);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.LESSTHOUSAND, gst.LessThousand, EnumCommand.DataType.Money);
                    result = _vehicleRepository.InsertGst(dv);
                    if (ConversionHelper.ToInt32(result.ReturnValue) == -1)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Gst not Save...!", MessageCatalog.ToastrTypes.Error);
                    else if (ConversionHelper.ToInt32(result.ReturnValue) == 1)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Gst Saved...!", MessageCatalog.ToastrTypes.Success);
                }
                else
                    TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Gst not saved because value is empty....!", MessageCatalog.ToastrTypes.Error);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return RedirectToAction("Index");
        }
        #endregion
        #region Show Customer Report
        /// <summary>
        /// To show registerion page
        /// </summary>
        /// <returns></returns>
        public IActionResult CustomerReport()
        {
            return View();
        }
        #endregion
        #region  FetchCustomerDetails        public JsonResult FetchCustomerDetails(Int64 Entries, Int64 Pages, Int64 OffsetRows)        {            DataValue dv = new DataValue();            try            {                dv.Add(MessageCatalog.Customer.CustomerProperty.OffsetRows, OffsetRows, EnumCommand.DataType.Int);                dv.Add(MessageCatalog.Customer.CustomerProperty.Entries, Entries, EnumCommand.DataType.Int);                customerCommanModel.customermodelList = _vehicleRepository.FetchCustomerReport(dv).customermodelList;                customerCommanModel.Count = _vehicleRepository.FetchCustomerReport(dv).Count;            }            catch (Exception ex)            {                new ErrorLog().WriteLog(ex);            }            return new JsonResult(customerCommanModel);        }        #endregion
    }
}
