using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleServiceManagement.Data;
using VehicleServiceManagement.Models;
using VehicleSeviceManagement.Framework;
using System.Text;
using GemBox.Spreadsheet;
using VehicleSeviceManagement.Framework.Helper;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleServiceManagement.Controllers
{
    public class VehicleController : Controller
    {
        //Injecting a Vehicle repository
        private readonly IVehicleRepository _vehicleRepository;
        //Constructor of Vehicel repository
        public VehicleController(IVehicleRepository _vehicleRepository)
        {
            this._vehicleRepository = _vehicleRepository;
        }
        // Creating an object for Comman model
        CustomerCommanModel customerCommanModel = new CustomerCommanModel();
        #region Show VehicleDetails
        public IActionResult VehicleDetails()
        {
            return View();
        }
        #endregion
        #region Show Registertion 
        // To show an registertion page
        public IActionResult Registertion()
        {
            return View();
        }
        #endregion
        #region Check Login 
        // To show an registertion page
        public IActionResult CheckLogin(CustomerModel customer)
        {
            try
            {
                if (!string.IsNullOrEmpty(customer.Email) && !string.IsNullOrEmpty(customer.Password))
                {
                    CustomerCommanModel customerCommanModel = new CustomerCommanModel();
                    DataValue dv = new DataValue();
                    dv.Add(MessageCatalog.Customer.CustomerProperty.EMAIL, customer.Email, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.PASSWORD, customer.Password, EnumCommand.DataType.String);
                    customerCommanModel = _vehicleRepository.CheckUserName(dv);
                    if (customerCommanModel.customermodelList != null)
                    {
                        HttpContext.Session.SetInt32(MessageCatalog.Customer.CustomerProperty.USERROLL,  customerCommanModel.customermodelList[0].UserRoll);
                        HttpContext.Session.SetInt32(MessageCatalog.Customer.CustomerProperty.CUSTOMERID, customerCommanModel.customermodelList[0].CustomerId);
                        HttpContext.Session.SetString(MessageCatalog.Customer.CustomerProperty.CUSTOMERNAME, customerCommanModel.customermodelList[0].CustomerName);

                        TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Customer Details", "sucess");

                        return RedirectToAction("Index", customerCommanModel);
                    }
                    TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Customer Details", "error");
                }
               
            }
            catch(Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return RedirectToAction("Registertion");
        }
        #endregion
        #region Index Page
        public IActionResult Index()
        {
            return View();
        }
        #endregion
        #region Save Customer Details
        /// <summary>
        ///  Insert an customer Registertion records  into db
        /// </summary>
        /// <param name="customer"> Creating a object for customermodel so that we can access its property</param>
        /// <returns></returns>
        public IActionResult SaveCustomer(CustomerModel customer)
        {
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToInt32(customer.CustomerId).ToString()) && !string.IsNullOrEmpty(customer.CustomerName)
                && !string.IsNullOrEmpty(customer.Email) && !string.IsNullOrEmpty(customer.MobileNo) && !string.IsNullOrEmpty(customer.Address)
                && !string.IsNullOrEmpty(customer.Password))
                {
                    ResultArgs result = new ResultArgs();
                    DataValue dv = new DataValue();
                    dv.Add(MessageCatalog.Customer.CustomerProperty.CUSTOMERID, customer.CustomerId, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.CUSTOMERNAME, customer.CustomerName, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.EMAIL, customer.Email, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.MOBILENO, customer.MobileNo, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.ADDRESS, customer.Address, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.PASSWORD, customer.Password, EnumCommand.DataType.String);
                    result = _vehicleRepository.InsertCutomerRegistertion(dv);
                    if (Convert.ToInt32(result.ReturnValue) == -1)
                    {
                        TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Customer Details", "error");
                    }
                    else if (Convert.ToInt32(result.ReturnValue) == 1)
                    {

                        TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Customer Details", "success");
                    }


                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View("Registertion");
        }
        #endregion
        #region Fetch Complaints 
        /// <summary>
        /// To Fetch an complaints form db
        /// </summary>
        /// <returns></returns>
        public IActionResult Complaints()
        {
            DataValue dv = null;
            customerCommanModel = _vehicleRepository.FetchComplaints(dv);
            return View(customerCommanModel);
        }
        #endregion
        #region To show an Complaint form
        /// <summary>
        /// To show an Complaints Forms
        /// </summary>
        /// <returns></returns>

        public IActionResult Complaintsform()
        {

            return View();
        }
        #endregion
        #region Edit Complaints
        public IActionResult EditComplaint(int ComplaintId)
        {
            DataValue dv = null;
            customerCommanModel = _vehicleRepository.FetchComplaints(dv);
            var EditOption = customerCommanModel.customerComplaintsList.Where(a => a.ComplaintId == ComplaintId).ToList().FirstOrDefault();
            customerCommanModel.customerComplaints = EditOption;
            return View("Complaintsform", customerCommanModel);
        }
        #endregion
        #region Delete Complaints
        public IActionResult DeleteComplaint(int ComplaintId)
        {
            DataValue dv = new DataValue();
            ResultArgs result = new ResultArgs();
            dv.Add("ComplaintId", ComplaintId, EnumCommand.DataType.Int32);
            result = _vehicleRepository.DeleteComplaints(dv);
            return View("Complaintsform");
        }
        #endregion
        #region Insert an Complaints 
        public IActionResult SaveComplaints(CustomerComplaints customerComplaints)
        {
            try
            {

            if (!string.IsNullOrEmpty(Convert.ToInt32(customerComplaints.ComplaintId).ToString()) && !string.IsNullOrEmpty(customerComplaints.Complaints) && !string.IsNullOrEmpty(Convert.ToDecimal(customerComplaints.Price).ToString()) && !string.IsNullOrEmpty(Convert.ToInt32(customerComplaints.VehicleTypeId).ToString()))
            {
                ResultArgs result = new ResultArgs();
                DataValue dv = new DataValue();
                dv.Add(MessageCatalog.Customer.CustomerProperty.COMPLAINTID, customerComplaints.ComplaintId, EnumCommand.DataType.String);
                dv.Add(MessageCatalog.Customer.CustomerProperty.COMPLAINTS, customerComplaints.Complaints, EnumCommand.DataType.String);
                dv.Add(MessageCatalog.Customer.CustomerProperty.PRICE, customerComplaints.Price, EnumCommand.DataType.String);
                dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLETYPEID, customerComplaints.VehicleTypeId, EnumCommand.DataType.String);
                result = _vehicleRepository.InsertComplaints(dv);
                if (Convert.ToInt32(result.ReturnValue) == -1)
                {
                    TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Customer Details", "error");
                }
                else if (Convert.ToInt32(result.ReturnValue) == 1)
                {

                    TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Complaints", "success");
                }
            }

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Complaints");
        }
        #endregion
        #region Get Vehicle Type
        public JsonResult GetVehicleType()
        {
            DataValue dv = null;
            customerCommanModel = _vehicleRepository.FetchVehicleTypes(dv);
            return new JsonResult(customerCommanModel);
        }
        #endregion
        #region Get Particular Complaints
        public JsonResult GetComplaints(CustomerComplaints customerComplaints)
        {
            DataValue dv = new DataValue();
            dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLETYPEID, customerComplaints.VehicleTypeId, EnumCommand.DataType.String);
            customerCommanModel = _vehicleRepository.FetchCustomerComplaints(dv);
            return new JsonResult(customerCommanModel);
        }
        #endregion
        #region Show Report
        /// <summary>
        /// Show an Report to Admin
        /// </summary>
        /// <returns></returns>
        public IActionResult Report()
        {
            DataValue dv = null;
            customerCommanModel = _vehicleRepository.FetchanReport(dv);
            return View(customerCommanModel);
        }
        #endregion
        #region Save Vehicle Details
        /// <summary>
        ///  Insert an Vehicle Details  into db
        /// </summary>
        /// <param name="vehicle"> Creating a object for VehicleDetails so that we can access its property</param>
        /// <returns></returns>
        public IActionResult SaveVehicle(VehicleDetails vehicle)
        {
            try
            {


                if (!string.IsNullOrEmpty(Convert.ToInt32(vehicle.VehicleId).ToString()) && !string.IsNullOrEmpty(vehicle.VehicleNo)
                && !string.IsNullOrEmpty(vehicle.VehicleBrand) && !string.IsNullOrEmpty(Convert.ToInt32(vehicle.VehicleModel).ToString()) && !string.IsNullOrEmpty(vehicle.VehicleColor)
                && !string.IsNullOrEmpty(Convert.ToDecimal(vehicle.VehicleKmsRan).ToString()) && !string.IsNullOrEmpty(Convert.ToDateTime(vehicle.ExpectedDelivery).ToString())
                && !string.IsNullOrEmpty(Convert.ToDecimal(vehicle.TotalPrice).ToString()) && !string.IsNullOrEmpty(vehicle.ComplaintId))
                {
                    ResultArgs result = new ResultArgs();
                    DataValue dv = new DataValue();
                    dv.Add(MessageCatalog.Customer.CustomerProperty.CUSTOMERID, HttpContext.Session.GetInt32(MessageCatalog.Customer.CustomerProperty.CUSTOMERID), EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLEID, vehicle.VehicleId, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLENO, vehicle.VehicleNo, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLEBRAND, vehicle.VehicleBrand, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLEMODEL, vehicle.VehicleModel, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLECOLOR, vehicle.VehicleColor, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLEKMSRAN, vehicle.VehicleKmsRan, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLETYPEID, vehicle.VehicleTypeId, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.COMPLAINTID, Request.Form["ComplaintId"], EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.TOTALPRICE, vehicle.TotalPrice, EnumCommand.DataType.String);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.EXPECTEDDELIVERY,Convert.ToDateTime(Request.Form["ExpectedDelivery"]), EnumCommand.DataType.DateTime);
                   
                    result = _vehicleRepository.InsertVehicleDetails(dv);
                    if (Convert.ToInt32(result.ReturnValue) == -1)
                    {
                        TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Customer Details", "error");
                    }
                    else if (Convert.ToInt32(result.ReturnValue) == 1)
                    {

                        TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Vehicle Details", "success");
                    }
                    else if (Convert.ToInt32(result.ReturnValue) == 2)
                    {

                        TempData["ToastrMessage"] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Vehicle Details", "success");
                    }
                }
            }
            catch(Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return RedirectToAction("ViewVehicleDetails");
        }
        #endregion
        #region To Fetch an vehicle Details
        /// <summary>
        /// To Fetch an vehicle Details form db
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewVehicleDetails()
        {

            DataValue dv = null;
            if(HttpContext.Session.GetInt32(MessageCatalog.Customer.CustomerProperty.USERROLL)==2)
            {
                customerCommanModel = _vehicleRepository.FetchVehicleDetails(dv);
                customerCommanModel = _vehicleRepository.FetchComplaints(dv);
            }
            customerCommanModel = _vehicleRepository.FetchVehicleDetails(dv);
            customerCommanModel = _vehicleRepository.FetchComplaints(dv);
            return View(customerCommanModel);
        }
        #endregion
        [HttpPost]
        public void SetExportOptions(string exportHtml, string exportType, string fileName)
        {
            HttpContext.Session.SetString("ExportContent", exportHtml);
            HttpContext.Session.SetString("ExportType", exportType);
            HttpContext.Session.SetString("ExportFileName", fileName);
        }
        public IActionResult Export(report report)
        {
            string extension = HttpContext.Session.GetString("ExportType").Equals("1") ? ".doc" : ".xls";
            string contentType = HttpContext.Session.GetString("ExportType").Equals("1") ? "application/ms-word" : "application/vnd.ms-excel";
            string fileName = HttpContext.Session.GetString("ExportFileName");

            return File(Encoding.ASCII.GetBytes(HttpContext.Session.GetString("ExportContent")), contentType, fileName + extension);
        }
        public IActionResult Vehicle()
        {
            return View();
        }
        #region Edit Vehicle Details
        public IActionResult EditVehicle(int VehicleId)
        {
            DataValue dv = null;
            customerCommanModel = _vehicleRepository.FetchVehicleDetails(dv);
            var EditOption = customerCommanModel.vehicleDetailsList.Where(a => a.VehicleId==VehicleId).ToList().FirstOrDefault();
            customerCommanModel.vehicleDetails = EditOption;
            return View("VehicleDetails", customerCommanModel);
        }
        #endregion
        #region Delete Vehicle Details
        public IActionResult DeleteVehicle(int VehicleId)
        {
            DataValue dv = new DataValue();
            ResultArgs result = new ResultArgs();
            dv.Add("VehicleId", VehicleId, EnumCommand.DataType.Int32);
            result = _vehicleRepository.DeleteVehicle(dv);
            return View("ViewVehicleDetails");
        }
        #endregion
        public IActionResult GetTotalPrice()
        {
            DataValue dv = new DataValue();
            dv.Add(MessageCatalog.Customer.CustomerProperty.COMPLAINTID, Request.Form["ComplaintId"], EnumCommand.DataType.String);
            return View();
        }
    }
}
