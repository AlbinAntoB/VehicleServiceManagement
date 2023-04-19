/***********************************************************************************************************
 * Created by       : Albin Anto
 * Created On       : 20th Oct 2021
 * 
 * Reviewed By      : Hilda sister
 * Reviewed On      : 26th Nov 2021
 * 
 ***********************************************************************************************************/
namespace VehicleServiceManagement.Areas.VehicleDetail.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using VehicleServiceManagement.Areas.Complaints.Data;
    using VehicleServiceManagement.Areas.Complaints.Models;
    using VehicleServiceManagement.Areas.VehicleDetail.Data;
    using VehicleServiceManagement.Areas.VehicleDetail.Models;
    using VehicleSeviceManagement.Framework;
    using VehicleSeviceManagement.Framework.Helper;
    [Area("VehicleDetail")]
    public class VehicleDetailController : Controller
    {
        //Injecting a VehicleDetail repository
        private readonly IVehicleDetailRepository _VehicleDetailRepository;
        //Injecting a Complaints Repository
        private readonly IComplaintsRepository _ComplaintsRepository;
        /// <summary>
        /// Constructor of VehicleDetail repository
        /// </summary>
        /// <param name="_VehicleDetailRepository"></param>
        /// <param name="_ComplaintsRepository"></param>
        public VehicleDetailController(IVehicleDetailRepository _VehicleDetailRepository, IComplaintsRepository _ComplaintsRepository)
        {
            this._VehicleDetailRepository = _VehicleDetailRepository;
            this._ComplaintsRepository = _ComplaintsRepository;
        }
        // Creating an object for Comman model
        VehicleCommanModel customerCommanModel = new VehicleCommanModel();
        #region Show VehicleDetails
        /// <summary>
        /// To show vehicle details form
        /// </summary>
        /// <returns></returns>
        public IActionResult VehicleDetails()
        {
            VehicleDetails vehicle = new VehicleDetails();
            vehicle.ComplaintId = " ";
            vehicle.VehicleTypeId = 0;
            customerCommanModel.vehicleDetails = vehicle;
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
                //if(ModelState.IsValid)
                if (!string.IsNullOrEmpty(vehicle.VehicleId.ToString()) && !string.IsNullOrEmpty(vehicle.VehicleNo)
                && !string.IsNullOrEmpty(vehicle.VehicleBrand) && !string.IsNullOrEmpty(vehicle.VehicleModel.ToString()) && !string.IsNullOrEmpty(vehicle.VehicleColor)
                && !string.IsNullOrEmpty(vehicle.VehicleKmsRan.ToString()) && !string.IsNullOrEmpty(vehicle.ExpectedDelivery.ToString())
                && !string.IsNullOrEmpty(vehicle.TotalPrice.ToString()) && !string.IsNullOrEmpty(vehicle.ComplaintId))
                {
                    ResultArgs result = new ResultArgs();
                    DataValue dv = new DataValue();
                    dv.Add(MessageCatalog.Customer.CustomerProperty.CUSTOMERID, HttpContext.Session.GetInt32(MessageCatalog.Customer.CustomerProperty.CUSTOMERID), EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLEID, vehicle.VehicleId, EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLENO, vehicle.VehicleNo, EnumCommand.DataType.Varchar);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLEBRAND, vehicle.VehicleBrand, EnumCommand.DataType.Varchar);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLEMODEL, vehicle.VehicleModel, EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLECOLOR, vehicle.VehicleColor, EnumCommand.DataType.Varchar);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLEKMSRAN, vehicle.VehicleKmsRan, EnumCommand.DataType.Decimal);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLETYPEID, vehicle.VehicleTypeId, EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.COMPLAINTID, Request.Form["ComplaintId"], EnumCommand.DataType.Varchar);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.TOTALPRICE, vehicle.TotalPrice, EnumCommand.DataType.Money);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.EXPECTEDDELIVERY, ConversionHelper.ToDateTime(Request.Form["ExpectedDelivery"]), EnumCommand.DataType.DateTime);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.DELIVERYSTATUS, vehicle.DeliveryStatus, EnumCommand.DataType.Varchar);

                    result = _VehicleDetailRepository.InsertVehicleDetails(dv);
                    if (ConversionHelper.ToInt32(result.ReturnValue) == -1)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Vehicle Details not Saved..!", MessageCatalog.ToastrTypes.Error);
                    else if (ConversionHelper.ToInt32(result.ReturnValue) == 1)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Vehicle Details Saved..!", MessageCatalog.ToastrTypes.Success);
                    else if (ConversionHelper.ToInt32(result.ReturnValue) == 2)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Vehicle Details Updated Successfully.", MessageCatalog.ToastrTypes.Success);
                }
                else
                    TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Vehicle details not saved because value is empty..!", MessageCatalog.ToastrTypes.Error);

            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return RedirectToAction("ViewVehicleDetails");
        }
        #endregion
        #region View Vehicle Details
        /// <summary>
        /// To Fetch an vehicle Details form db
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewVehicleDetails()
        {
            DataValue dv = new DataValue();
            if (HttpContext.Session.GetInt32(MessageCatalog.Customer.CustomerProperty.USERROLL) == 2)
            {
                DataValue dv1 = new DataValue();
                int CustomerId = ConversionHelper.ToInt32(HttpContext.Session.GetInt32(MessageCatalog.Customer.CustomerProperty.CUSTOMERID));
                dv1.Add(MessageCatalog.Customer.CustomerProperty.CUSTOMERID, CustomerId, EnumCommand.DataType.Int);
                customerCommanModel = _VehicleDetailRepository.FetchParticularVehicleDetails(dv1);
                //In that avialable list customerComplaintList
                customerCommanModel.customerComplaintsList = _ComplaintsRepository.FetchComplaints(dv).customerComplaintsList;
                customerCommanModel = _VehicleDetailRepository.FetchVehicleTypes(dv);
            }
            else
            {
                customerCommanModel = _VehicleDetailRepository.FetchVehicleDetails(dv);
                customerCommanModel.customerComplaintsList = _ComplaintsRepository.FetchComplaints(dv).customerComplaintsList;
                customerCommanModel = _VehicleDetailRepository.FetchVehicleTypes(dv);
            }
            return View(customerCommanModel);
        }
        #endregion
        #region Edit Vehicle Details
        /// <summary>
        /// Edit Vehicle Details
        /// </summary>
        /// <param name="VehicleId">This parameter to edit vehicle details by linq</param>
        /// <returns></returns>
        public IActionResult EditVehicle(int VehicleId)
        {
            customerCommanModel = _VehicleDetailRepository.FetchVehicleDetails();
            var EditOption = customerCommanModel.vehicleDetailsList.Where(a => a.VehicleId == VehicleId).ToList().FirstOrDefault();
            customerCommanModel.vehicleDetails = EditOption;
            return View("VehicleDetails", customerCommanModel);
        }
        #endregion
        #region Delete Vehicle Details
        /// <summary>
        /// Delete Vehicle Details
        /// </summary>
        /// <param name="VehicleId">This parameter to delete vehicle details</param>
        /// <returns></returns>
        public IActionResult DeleteVehicle(int VehicleId)
        {
            DataValue dv = new DataValue();
            ResultArgs result = new ResultArgs();
            dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLEID, VehicleId, EnumCommand.DataType.Int32);
            result = _VehicleDetailRepository.DeleteVehicle(dv);
            if (result.Success)
                TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Vehicle Details Deleted!", MessageCatalog.ToastrTypes.Success);
            return RedirectToAction("ViewVehicleDetails");
        }
        #endregion
        #region Get Vehicle Type
        /// <summary>
        /// Get Vehicle Type
        /// </summary>
        /// <returns></returns>
        public JsonResult GetVehicleType()
        {
            customerCommanModel = _VehicleDetailRepository.FetchVehicleTypes();
            return new JsonResult(customerCommanModel);
        }
        #endregion
        #region Get Particular Complaints
        /// <summary>
        ///  Get Particular Complaints
        /// </summary>
        /// <param name="customerComplaints">By this parameter can get its property</param>
        /// <returns></returns>
        public JsonResult GetComplaints(CustomerComplaints customerComplaints)
        {
            DataValue dv = new DataValue();
            dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLETYPEID, customerComplaints.VehicleTypeId, EnumCommand.DataType.Int);
            customerCommanModel.customerComplaintsList = _ComplaintsRepository.FetchCustomerComplaints(dv).customerComplaintsList;
            return new JsonResult(customerCommanModel);
        }
















        #endregion
        #region  Fetch staff details
        /// <summary>
        /// Fetch staff details
        /// </summary>
        /// <param name="Entries"></param>
        /// <param name="Pages"></param>
        /// <param name="OffsetRows"></param>
        /// <returns></returns>
        public JsonResult FetchVehicleDetails(Int64 Entries, Int64 Pages, Int64 OffsetRows)
        {
            VehicleDetails vehicleDetails = new VehicleDetails();
            DataValue dv = new DataValue();
            try
            {
                dv.Add(MessageCatalog.Customer.CustomerProperty.OffsetRows, OffsetRows, EnumCommand.DataType.Int);
                dv.Add(MessageCatalog.Customer.CustomerProperty.Entries, Entries, EnumCommand.DataType.Int);
                customerCommanModel = _VehicleDetailRepository.FetchVehicleDetails(dv);
                customerCommanModel.vehicleDetails= vehicleDetails;
                //objstaffdetails.Count = _IManageStaff.FetchStaffDetails(dv).Count;
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return new JsonResult(customerCommanModel);
        }
        #endregion

    }
}