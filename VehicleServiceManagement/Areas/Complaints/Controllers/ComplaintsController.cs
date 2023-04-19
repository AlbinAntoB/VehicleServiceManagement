/*********************************************************************************************************** * Created by       : Albin Anto * Created On       : 20th Oct 2021 *  * Reviewed By      : Hilda sister * Reviewed On      : 26th Nov 2021 *  ***********************************************************************************************************/
namespace VehicleServiceManagement.Areas.Complaints.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using VehicleServiceManagement.Areas.Complaints.Data;
    using VehicleServiceManagement.Areas.Complaints.Models;
    using VehicleServiceManagement.Areas.VehicleDetail.Data;
    using VehicleSeviceManagement.Framework;
    using VehicleSeviceManagement.Framework.Helper;
    [Area("Complaints")]
    public class ComplaintsController : Controller
    {
        // Creating an object for Comman model
        ComplaintsCommanModel ComplaintsCommanModel = new ComplaintsCommanModel();
        //Injecting a Complaints repository
        private readonly IComplaintsRepository _ComplaintsRepository;
        //Injecting a VehicleDetail repository
        private readonly IVehicleDetailRepository _VehicleDetailRepository;
        /// <summary>
        /// Constructor of Complaints repository
        /// </summary>
        /// <param name="_ComplaintsRepository"></param>
        /// <param name="_VehicleDetailRepository"></param>
        public ComplaintsController(IComplaintsRepository _ComplaintsRepository, IVehicleDetailRepository _VehicleDetailRepository)
        {
            this._ComplaintsRepository = _ComplaintsRepository;
            this._VehicleDetailRepository = _VehicleDetailRepository;
        }
        #region To show an Complaint form
        /// <summary>
        /// To show an Complaints Forms
        /// </summary>
        /// <returns></returns>
        public IActionResult Complaintsform()
        {
            DataValue dv = new DataValue();
            CustomerComplaints customer = new CustomerComplaints();
            customer.ComplaintId = 0;
            ComplaintsCommanModel.customerComplaints = customer;
            ComplaintsCommanModel.vehicleTypesList = _VehicleDetailRepository.FetchVehicleTypes(dv).vehicleTypesList;
            return View("ComplaintsDetails", ComplaintsCommanModel);
        }
        #endregion
        #region To save complaints
        /// <summary>
        /// To save complaints
        /// </summary>
        /// <param name="customerComplaints"></param>
        /// <returns></returns>
        public IActionResult SaveComplaints(CustomerComplaints customerComplaints)
        {
            try
            {
                if (!string.IsNullOrEmpty(customerComplaints.Complaints) && !string.IsNullOrEmpty(customerComplaints.Price.ToString()) && !string.IsNullOrEmpty(customerComplaints.VehicleTypeId.ToString()))
                {
                    ResultArgs result = new ResultArgs();
                    DataValue dv = new DataValue();
                    dv.Add(MessageCatalog.Customer.CustomerProperty.COMPLAINTID, customerComplaints.ComplaintId, EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.COMPLAINTS, customerComplaints.Complaints, EnumCommand.DataType.Varchar);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.PRICE, customerComplaints.Price, EnumCommand.DataType.Money);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.VEHICLETYPEID, Request.Form["VehicleTypeId"], EnumCommand.DataType.Int);
                    result = _ComplaintsRepository.InsertComplaints(dv);
                    if (ConversionHelper.ToInt32(result.ReturnValue) == -1)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Complaints not yet Saved!", MessageCatalog.ToastrTypes.Error);
                    else if (ConversionHelper.ToInt32(result.ReturnValue) == 1)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Complaints Saved!", MessageCatalog.ToastrTypes.Success);
                    else if (ConversionHelper.ToInt32(result.ReturnValue) == 2)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Complaints Updated successfully!", MessageCatalog.ToastrTypes.Success);
                }
                else
                    TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Complaints not saved because value is empty!", MessageCatalog.ToastrTypes.Error);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return RedirectToAction("Complaints");
        }
        #endregion
        #region Fetch Complaints 
        /// <summary>
        /// To Fetch an complaints form db
        /// </summary>
        /// <returns></returns>
        public IActionResult Complaints()
        {
            DataValue dv = new DataValue();
            ComplaintsCommanModel = _ComplaintsRepository.FetchComplaints(dv);
            ComplaintsCommanModel.vehicleTypesList = _VehicleDetailRepository.FetchVehicleTypes(dv).vehicleTypesList;
            return View(ComplaintsCommanModel);
        }
        #endregion
        #region Edit Complaints
        /// <summary>
        /// To edit complaints
        /// </summary>
        /// <param name="ComplaintId">This parameter to edit complaint by linq</param>
        /// <returns></returns>
        public IActionResult EditComplaint(int ComplaintId)
        {
            ComplaintsCommanModel = _ComplaintsRepository.FetchComplaints();
            var EditOption = ComplaintsCommanModel.customerComplaintsList.Where(a => a.ComplaintId == ComplaintId).ToList().FirstOrDefault();
            ComplaintsCommanModel.customerComplaints = EditOption;
            return View("ComplaintsDetails", ComplaintsCommanModel);
        }
        #endregion
        #region Delete Complaints
        /// <summary>
        /// To delete complaints
        /// </summary>
        /// <param name="ComplaintId">This parameter to delete complaint</param>
        /// <returns></returns>
        public IActionResult DeleteComplaint(int ComplaintId)
        {
            DataValue dv = new DataValue();
            ResultArgs result = new ResultArgs();
            dv.Add(MessageCatalog.Customer.CustomerProperty.COMPLAINTID, ComplaintId, EnumCommand.DataType.Int32);
            result = _ComplaintsRepository.DeleteComplaints(dv);
            if (result.Success)
                TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Complaints Deleted!", MessageCatalog.ToastrTypes.Success);
            return RedirectToAction("Complaints");
        }
        #endregion
        #region Get Vehicle Type
        /// <summary>
        /// To get an vehicle type
        /// </summary>
        /// <returns></returns>
        public JsonResult GetVehicleType()
        {
            DataValue dv = new DataValue();
            ComplaintsCommanModel.vehicleTypesList = _VehicleDetailRepository.FetchVehicleTypes(dv).vehicleTypesList;
            return new JsonResult(ComplaintsCommanModel);
        }
        #endregion
    }
}
