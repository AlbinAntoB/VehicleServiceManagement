/*********************************************************************************************************** * Created by       : Albin Anto * Created On       : 20th Oct 2021 *  * Reviewed By      : Hilda sister * Reviewed On      : 26th Nov 2021 *  ***********************************************************************************************************/
namespace VehicleServiceManagement.Areas.Report.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Text;
    using VehicleServiceManagement.Areas.Report.Data;
    using VehicleServiceManagement.Areas.Report.Models;
    using VehicleSeviceManagement.Framework;
    using VehicleSeviceManagement.Framework.Helper;
    [Area("Report")]
    public class ReportController : Controller
    {
        //Injecting a IReportrepository
        private readonly IReportRepository _ReportRepository;
        //Constructor of Report repository
        public ReportController(IReportRepository _ReportRepository)
        {
            this._ReportRepository = _ReportRepository;
        }
        // Creating an object for Comman model
        reportCommanModel ReportCommanModel = new reportCommanModel();
        #region Show Report
        /// <summary>
        /// Show an Report to Admin
        /// </summary>
        /// <returns></returns>
        public IActionResult Report()
        {
            ReportCommanModel = _ReportRepository.FetchanReport();
            return View(ReportCommanModel);
        }
        #endregion
        #region Export Options 
        /// <summary>
        /// This is to export an data's
        /// </summary>
        /// <param name="exportHtml"></param>
        /// <param name="exportType"></param>
        /// <param name="fileName"></param>
        public void SetExportOptions(string exportHtml, string exportType, string fileName)
        {
            HttpContext.Session.SetString("ExportContent", exportHtml);
            HttpContext.Session.SetString("ExportType", exportType);
            HttpContext.Session.SetString("ExportFileName", fileName);
        }
        public IActionResult Export()
        {
            string extension = HttpContext.Session.GetString("ExportType").Equals("1") ? ".doc" : ".xls";
            string contentType = HttpContext.Session.GetString("ExportType").Equals("1") ? "application/ms-word" : "application/vnd.ms-excel";
            string fileName = HttpContext.Session.GetString("ExportFileName");
            return File(Encoding.ASCII.GetBytes(HttpContext.Session.GetString("ExportContent")), contentType, fileName + extension);
        }
        #endregion
        #region ServiceReport
        /// <summary>
        /// This is service report page
        /// </summary>
        /// <returns></returns>
        public IActionResult ServiceReport()
        {
            ReportCommanModel = _ReportRepository.FetchServiceReport();
            return View(ReportCommanModel);
        }
        #endregion
        #region Feedback
        /// <summary>
        /// To view feedback page
        /// </summary>
        /// <returns></returns>
        public IActionResult Feedback()
        {
            return View();
        }
        #endregion
        #region Save Feedback
        /// <summary>
        /// To save Feedback given by customer
        /// </summary>
        /// <returns></returns>
        public IActionResult SaveFeedback()
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.Form["commentText"].ToString()))
                {
                    ResultArgs result = new ResultArgs();
                    DataValue dv = new DataValue();
                    dv.Add(MessageCatalog.Customer.CustomerProperty.CUSTOMERID, HttpContext.Session.GetInt32(MessageCatalog.Customer.CustomerProperty.CUSTOMERID), EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.OVERALL, Request.Form["rating1"], EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.ALLPROBLEMS, Request.Form["rating2"], EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.DELIVERYVEHICLE, Request.Form["rating"], EnumCommand.DataType.Int);
                    dv.Add(MessageCatalog.Customer.CustomerProperty.ANYOTHERSUGGESTIONS, Request.Form["commentText"], EnumCommand.DataType.Varchar);
                    result = _ReportRepository.InsertFeedback(dv);
                    if (ConversionHelper.ToInt32(result.ReturnValue) == -1)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Feedback Unable To Save!", MessageCatalog.ToastrTypes.Error);
                    else if (ConversionHelper.ToInt32(result.ReturnValue) == 1)
                        TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Success, "Feedback Saved!", MessageCatalog.ToastrTypes.Success);
                }
                else
                    TempData[MessageCatalog.ToastrTypes.ToastrMessage] = string.Format(MessageCatalog.ToastrStyle.Toastr_Style, MessageCatalog.ToastrTypes.Error, "Feedback not saved because value is empty!", MessageCatalog.ToastrTypes.Error);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return View("Feedback");
        }
        #endregion
    }
}