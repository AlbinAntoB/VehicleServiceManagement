namespace VehicleServiceManagement.Areas.Service.Data
{
    using System;
    using System.Data;
    using System.Linq;
    using VehicleServiceManagement.Areas.Service.Models;
    using VehicleSeviceManagement.DbEngine;
    using VehicleSeviceManagement.Framework;
    using VehicleSeviceManagement.Framework.Helper;
    public interface IServiceRepository
    { 
        // To Insert an ServiceFollowup
        ResultArgs InsertServiceFollowup(DataValue dv);
        //To Fetch Service Followup
        SeviceFollowCommanModel FetchServiceFollowup(DataValue dv);
        // To Delete an service
        ResultArgs DeleteService(DataValue dv);
    }
    public class ServiceRepository:IServiceRepository
    {
        //  Creating an Object for Comman Model
        SeviceFollowCommanModel customer = new SeviceFollowCommanModel();
        #region Common for SqlServer injecting
        // Declaring  String varible for Query or Stored procedure
        private string sSQL;

        // Creating an object for SqlSqrver Handler
        private ISqlServerHanlder objHandler;
        /// <summary>
        ///Injecting  a SQlServerHandler by constructor
        /// </summary>
        /// <param name="sqlServerHanlder"></param>
        public ServiceRepository(ISqlServerHanlder sqlServerHanlder)
        {
            objHandler = sqlServerHanlder;
        }
        #endregion
        #region Insert ServiceFollowup
        /// <summary>
        /// To insert service followup details
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ResultArgs InsertServiceFollowup(DataValue dv)
        {

            sSQL = "[dbo].[usp_InsertServiceFollowup]";
            return objHandler.ExecuteCommand(sSQL, dv, true, EnumCommand.SQLType.SQLStoredProcedure);
        }

        #endregion
        #region FetchServiceFollowup
        /// <summary>
        /// To fetch service Followup details
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public SeviceFollowCommanModel FetchServiceFollowup(DataValue dv)
        {
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchService(dv);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {

                    customer.serviceFollowupList = (from DataRow dr in result.DataSource.Table.Rows
                                                    select new ServiceFollowup
                                                    {
                                                        ServiceId = ConversionHelper.ToInt32(dr["ServiceId"]),
                                                        CustomerName = dr["CustomerName"].ToString(),
                                                        DeliveryOn = ConversionHelper.ToDateTime(dr["DeliveryOn"].ToString()),
                                                        TotalPrice = ConversionHelper.ToDecimal(dr["TotalPrice"]),
                                                        ReRepair = dr["ReRepair"].ToString(),
                                                        FromOn = ConversionHelper.ToDateTime(dr["FromOn"].ToString()),
                                                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;
        }
        public ResultArgs FetchService(DataValue dv)
        {
            sSQL = "[dbo].[usp_FetchServiceFollowup]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region Delete Service
        /// <summary>
        /// To delete service details
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ResultArgs DeleteService(DataValue dv)
        {
            sSQL = "[dbo].[usp_DeleteServie]";
            return objHandler.ExecuteCommand(sSQL, dv, false, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
    }
}
