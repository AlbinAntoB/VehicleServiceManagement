namespace VehicleServiceManagement.Areas.Report.Data
{
    using System;
    using System.Data;
    using System.Linq;
    using VehicleServiceManagement.Areas.Report.Models;
    using VehicleSeviceManagement.DbEngine;
    using VehicleSeviceManagement.Framework;
    using VehicleSeviceManagement.Framework.Helper;

    public interface IReportRepository
    {
        // To Fetch An Report
        reportCommanModel FetchanReport(DataValue dv = null);
        //To Fetch Service Report
        reportCommanModel FetchServiceReport(DataValue dv=null);

        // To Insert an Feedback
        ResultArgs InsertFeedback(DataValue dv);
    }
    public class ReportRepository : IReportRepository
    {
        //  Creating an Object for Comman Model
        reportCommanModel customer = new reportCommanModel();
        #region Common for SqlServer injecting
        // Declaring  String varible for Query or Stored procedure
        private string sSQL;

        // Creating an object for SqlSqrver Handler
        private ISqlServerHanlder objHandler;
        /// <summary>
        ///Injecting  a SQlServerHandler by constructor
        /// </summary>
        /// <param name="sqlServerHanlder"></param>
        public ReportRepository(ISqlServerHanlder sqlServerHanlder)
        {
            objHandler = sqlServerHanlder;
        }
        #endregion
        #region FetchServiceReport
        /// <summary>
        /// To fetch an report
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public reportCommanModel FetchServiceReport(DataValue dv)
        {
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchReportFeedback(dv);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {

                    customer.feedbackList = (from DataRow dr in result.DataSource.Table.Rows
                                             select new Feedback
                                             {
                                                 CustomerName = dr["CustomerName"].ToString(),
                                                 OverAll = ConversionHelper.ToInt32(dr["OverAll"]),
                                                 AllProblems = ConversionHelper.ToInt32(dr["AllProblems"]),
                                                 DeliveryVehicle = ConversionHelper.ToInt32(dr["DeliveryVehicle"]),
                                                 Anyothersuggestions = dr["Anyothersuggestions"].ToString(),
                                             }).ToList();
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;
        }
        public ResultArgs FetchReportFeedback(DataValue dv)
        {
            sSQL = "[dbo].[usp_FetchServiceReport]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region Insert Feedback
        /// <summary>
        /// Insert feedback given by customer
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ResultArgs InsertFeedback(DataValue dv)
        {

            sSQL = "[dbo].[usp_InsertFeedback]";
            return objHandler.ExecuteCommand(sSQL, dv, true, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region To Fetch An Report
        /// <summary>
        /// To Fetch an report details
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public reportCommanModel FetchanReport(DataValue dv)
        {
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchReportInfo(dv);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {
                    customer.reportList = (from DataRow dr in result.DataSource.Table.Rows
                                           select new report
                                           {

                                               CustomerName = dr["CustomerName"].ToString(),
                                               Email = dr["Email"].ToString(),
                                               MobileNo = dr["MobileNo"].ToString(),
                                               Address = dr["Address"].ToString(),
                                               VehicleNo = dr["VehicleNo"].ToString(),
                                               VehicleBrand = dr["VehicleBrand"].ToString(),
                                               VehicleModel = ConversionHelper.ToInt32(dr["VehicleModel"]),
                                               VehicleColor = dr["VehicleColor"].ToString(),
                                               VehicleKmsRan = ConversionHelper.ToDecimal(dr["TotalPrice"].ToString()),
                                               ExpectedDelivery = ConversionHelper.ToDateTime(dr["ExpectedDelivery"].ToString()),
                                               TotalPrice = ConversionHelper.ToDecimal(dr["TotalPrice"].ToString()),
                                           }).ToList();
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;
        }
        public ResultArgs FetchReportInfo(DataValue dv)
        {
            sSQL = "[dbo].[usp_FetchReport]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
    }
}
