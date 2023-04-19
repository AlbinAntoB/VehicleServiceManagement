namespace VehicleServiceManagement.Areas.Complaints.Data
{
    using System;
    using System.Data;
    using System.Linq;
    using VehicleServiceManagement.Areas.Complaints.Models;
    using VehicleSeviceManagement.DbEngine;
    using VehicleSeviceManagement.Framework;
    using VehicleSeviceManagement.Framework.Helper;
    public interface IComplaintsRepository
    {
        //To Fetch Customer Comman Complaints
        ComplaintsCommanModel FetchComplaints(DataValue dv=null);
        // To Insert an Complaints
        ResultArgs InsertComplaints(DataValue dv);
        //To Fetch Customer Pariticular Complaints
        ComplaintsCommanModel FetchCustomerComplaints(DataValue dv);
        //To Delete an Complaints
        ResultArgs DeleteComplaints(DataValue dv);
    }
    public class ComplaintsRepository: IComplaintsRepository
    {
        //  Creating an Object for Comman Model
        ComplaintsCommanModel customer = new ComplaintsCommanModel();
        #region Common for SqlServer injecting
        // Declaring  String varible for Query or Stored procedure
        private string sSQL;
        // Creating an object for SqlSqrver Handler
        private ISqlServerHanlder objHandler;
        /// <summary>
        /// Constructor of complaints repository
        /// </summary>
        /// <param name="sqlServerHanlder"></param>
        public ComplaintsRepository(ISqlServerHanlder sqlServerHanlder)
        {
            objHandler = sqlServerHanlder;
        }
        #endregion
        #region FetchComplaints
        /// <summary>
        /// To fetch complaints from db
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ComplaintsCommanModel FetchComplaints(DataValue dv)
        {
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchCommanComplaints(dv);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {
                    customer.customerComplaintsList = (from DataRow dr in result.DataSource.Table.Rows
                                                       select new CustomerComplaints
                                                       {
                                                           ComplaintId = ConversionHelper.ToInt32(dr["ComplaintId"]),
                                                           Complaints = dr["Complaints"].ToString(),
                                                           Price = ConversionHelper.ToDecimal(dr["Price"]),
                                                           VehicleTypeId = ConversionHelper.ToInt32(dr["VehicleTypeId"]),
                                                       }).ToList();
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;

        }
        public ResultArgs FetchCommanComplaints(DataValue dv)
        {
            sSQL = "[dbo].[usp_FetchComplaints]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region Insert Complaints
        /// <summary>
        /// Insert an complaints into db
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ResultArgs InsertComplaints(DataValue dv)
        {
            sSQL = "[dbo].[usp_InsertComplaints]";
            return objHandler.ExecuteCommand(sSQL, dv, true, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region Fetch Pariticular Complaints
        /// <summary>
        /// To fetch an Pariticular complaints from db
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ComplaintsCommanModel FetchCustomerComplaints(DataValue dv)
        {
            ComplaintsCommanModel customer = new ComplaintsCommanModel();

            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchParicularComplaint(dv);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {
                    customer.customerComplaintsList = (from DataRow dr in result.DataSource.Table.Rows
                                                       select new CustomerComplaints
                                                       {
                                                           ComplaintId = ConversionHelper.ToInt32(dr["ComplaintId"]),
                                                           Complaints = dr["Complaints"].ToString(),
                                                           Price = ConversionHelper.ToDecimal(dr["Price"]),
                                                           VehicleTypeId = ConversionHelper.ToInt32(dr["VehicleTypeId"]),
                                                       }).ToList();
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;

        }
        public ResultArgs FetchParicularComplaint(DataValue dv)
        {
            sSQL = "[dbo].[usp_FetchParticularComplaints]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }


        #endregion
        #region Delete Complaints
        /// <summary>
        /// To delete complaints
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ResultArgs DeleteComplaints(DataValue dv)
        {
            sSQL = "[dbo].[usp_DeleteComplaints]";
            return objHandler.ExecuteCommand(sSQL, dv, false, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
    }
}
