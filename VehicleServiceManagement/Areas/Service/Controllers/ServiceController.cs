/*********************************************************************************************************** * Created by       : Albin Anto * Created On       : 20th Oct 2021 *  * Reviewed By      : Hilda sister * Reviewed On      : 26th Nov 2021 *  ***********************************************************************************************************/
namespace VehicleServiceManagement.Areas.Service.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using VehicleServiceManagement.Areas.Service.Data;
    using VehicleServiceManagement.Areas.Service.Models;
    using VehicleSeviceManagement.Framework;
    using VehicleSeviceManagement.Framework.Helper;
    [Area("Service")]
    public class ServiceController : Controller
    {
        // Creating an object for Service model
        SeviceFollowCommanModel ServiceCommanModel = new SeviceFollowCommanModel();
        //Injecting a Service repository
        private readonly IServiceRepository _ServiceRepository;
        /// <summary>
        ///Constructor of Service repository
        /// </summary>
        /// <param name="_ServiceRepository"></param>
        public ServiceController(IServiceRepository _ServiceRepository)
        {
            this._ServiceRepository = _ServiceRepository;
        }
        #region To show an ServiceFollowup Page
        /// <summary>
        /// Service Followup page
        /// </summary>
        /// <returns></returns>
        public IActionResult ServiceFollowup()
        {
            return View("ServiceDetails");
        }
        #endregion
        #region Save an service
        /// <summary>
        /// To save service Followup details
        /// </summary>
        /// <param name="service">By this parameter can get it values</param>
        /// <returns></returns>
        public IActionResult SaveService(ServiceFollowup service)
        {
            try
            {
                if (!string.IsNullOrEmpty(service.ReRepair))
                {
                    ResultArgs result = new ResultArgs();
                    DataValue dv = new DataValue();
                    dv.Add(MessageCatalog.Customer.CustomerProperty.CUSTOMERID, HttpContext.Session.GetInt32(MessageCatalog.Customer.CustomerProperty.CUSTOMERID), EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.SERVICEID, service.ServiceId, EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.DELIVERYON, service.DeliveryOn, EnumCommand.DataType.DateTime);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.TOTALPRICE, service.TotalPrice, EnumCommand.DataType.Money);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.REREPAIR, service.ReRepair, EnumCommand.DataType.Varchar);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.FROMON, service.FromOn, EnumCommand.DataType.DateTime);
                    result = _ServiceRepository.InsertServiceFollowup(dv);
                    if (ConversionHelper.ToInt32(result.ReturnValue) == -1)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Service Details unable to Save!", MessageCatalog.ToastrTypes.Error);
                    else if (ConversionHelper.ToInt32(result.ReturnValue) == 1)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Service Details Saved Successfully",MessageCatalog.ToastrTypes.Success);
                    else if (ConversionHelper.ToInt32(result.ReturnValue) == 2)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Service Details Updated Successfully", MessageCatalog.ToastrTypes.Success);
                }
                else
                    TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Service details not saved because value is empty!", MessageCatalog.ToastrTypes.Error);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return RedirectToAction("ViewServiceFollowup");
        }
        #endregion
        #region Fetch an ServiceFolllowup
        /// <summary>
        /// To view service Followup details
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewServiceFollowup()
        {
            DataValue dv = new DataValue();
            if (HttpContext.Session.GetInt32(MessageCatalog.Customer.CustomerProperty.USERROLL) == 2)
            {
                int CustomerId = ConversionHelper.ToInt32(HttpContext.Session.GetInt32(MessageCatalog.Customer.CustomerProperty.CUSTOMERID));
                dv.Add(MessageCatalog.Customer.CustomerProperty.CUSTOMERID, CustomerId, EnumCommand.DataType.Int);
                ServiceCommanModel = _ServiceRepository.FetchServiceFollowup(dv);
            }
            else
                ServiceCommanModel = _ServiceRepository.FetchServiceFollowup(dv);
            return View("ViewServiceFollow", ServiceCommanModel);
        }
        #endregion
        #region Edit Service Details
        /// <summary>
        /// To edit service details
        /// </summary>
        /// <param name="ServiceId">This parameter to edit service by linq</param>
        /// <returns></returns>
        public IActionResult EditService(int ServiceId)
        {
            DataValue dv = new DataValue();
            ServiceCommanModel = _ServiceRepository.FetchServiceFollowup(dv);
            var EditOption = ServiceCommanModel.serviceFollowupList.Where(a => a.ServiceId == ServiceId).ToList().FirstOrDefault();
            ServiceCommanModel.serviceFollowup = EditOption;
            return View("ServiceDetails", ServiceCommanModel);
        }
        #endregion
        #region Delete Service Details
        /// <summary>
        /// To delete service Details
        /// </summary>
        /// <param name="ServiceId">This parameter to delete service</param>
        /// <returns></returns>
        public IActionResult DeleteService(int ServiceId)
        {
            DataValue dv = new DataValue();
            ResultArgs result = new ResultArgs();
            dv.Add(MessageCatalog.Customer.CustomerProperty.SERVICEID, ServiceId, EnumCommand.DataType.Int);
            result = _ServiceRepository.DeleteService(dv);
            if (result.Success)
                TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Service Details Deleted!",MessageCatalog.ToastrTypes.Success);
            return RedirectToAction("ViewServiceFollowup");
        }
        #endregion
    }
}
