namespace VehicleServiceManagement.Areas.VehicleDetail.Data
{
    using System;
    using System.Data;
    using System.Linq;
    using VehicleServiceManagement.Areas.VehicleDetail.Models;
    using VehicleSeviceManagement.DbEngine;
    using VehicleSeviceManagement.Framework;
    using VehicleSeviceManagement.Framework.Helper;
    public interface IVehicleDetailRepository
    {

        //To Fetch Customers Vehicle Details
        VehicleCommanModel FetchVehicleDetails(DataValue dv=null);
        //To Delete an Vehicle Details
        ResultArgs DeleteVehicle(DataValue dv);
        // To Insert an VehicleDetails
        ResultArgs InsertVehicleDetails(DataValue dv);
        //To Fetch Customers Particular Vehicle Details
        VehicleCommanModel FetchParticularVehicleDetails(DataValue dv1);
        //To Fetch Vehicle Types
        VehicleCommanModel FetchVehicleTypes(DataValue dv=null);
    }
    public class VehicleDetailRepository : IVehicleDetailRepository
    {
        //  Creating an Object for Comman Model
        VehicleCommanModel customer = new VehicleCommanModel();
        #region Common for SqlServer injecting
        // Declaring  String varible for Query or Stored procedure
        private string sSQL;

        // Creating an object for SqlSqrver Handler
        private ISqlServerHanlder objHandler;
        /// <summary>
        ///Injecting  a SQlServerHandler by constructor
        /// </summary>
        /// <param name="sqlServerHanlder"></param>
        public VehicleDetailRepository(ISqlServerHanlder sqlServerHanlder)
        {
            objHandler = sqlServerHanlder;
        }
        #endregion
        #region Insert an VehicleDetails
        /// <summary>
        /// To insert vehicle details
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ResultArgs InsertVehicleDetails(DataValue dv)
        {
            sSQL = "[dbo].[usp_InsertVehicleDetails]";
            return objHandler.ExecuteCommand(sSQL, dv, true, EnumCommand.SQLType.SQLStoredProcedure);

        }
        #endregion
        #region To Fetch An ParticularVehcile  Details
        /// <summary>
        /// To fetch particular vehicle details
        /// </summary>
        /// <param name="dv1"></param>
        /// <returns></returns>
        public VehicleCommanModel FetchParticularVehicleDetails(DataValue dv1)
        {
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchParticularVehicleData(dv1);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {
                    customer.vehicleDetailsList = (from DataRow dr in result.DataSource.Table.Rows
                                                   select new VehicleDetails
                                                   {

                                                       CustomerName = dr["CustomerName"].ToString(),
                                                       VehicleId = ConversionHelper.ToInt32(dr["VehicleId"]),
                                                       VehicleNo = dr["VehicleNo"].ToString(),
                                                       VehicleBrand = dr["VehicleBrand"].ToString(),
                                                       VehicleModel = ConversionHelper.ToInt32(dr["VehicleModel"]),
                                                       VehicleColor = dr["VehicleColor"].ToString(),
                                                       VehicleKmsRan = ConversionHelper.ToDecimal(dr["VehicleKmsRan"].ToString()),
                                                       VehicleTypeId = ConversionHelper.ToInt32(dr["VehicleTypeId"]),
                                                       ComplaintId = dr["ComplaintId"].ToString(),
                                                       ExpectedDelivery = ConversionHelper.ToDateTime(dr["ExpectedDelivery"].ToString()),
                                                       TotalPrice = ConversionHelper.ToDecimal(dr["TotalPrice"].ToString()),
                                                       DeliveryStatus = dr["DeliveryStatus"].ToString(),
                                                   }).ToList();
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;
        }
        public ResultArgs FetchParticularVehicleData(DataValue dv1)
        {
            sSQL = "[dbo].[usp_FetchParticularVehicleDetails]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv1, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region To Fetch An Vehcile Details
        /// <summary>
        ///  To Fetch An Vehcile Details
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public VehicleCommanModel FetchVehicleDetails(DataValue dv)
        {
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchVehicleData(dv);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {
                    customer.vehicleDetailsList = (from DataRow dr in result.DataSource.Table.Rows
                                                   select new VehicleDetails
                                                   {
                                                       CustomerName = dr["CustomerName"].ToString(),
                                                       VehicleId = ConversionHelper.ToInt32(dr["VehicleId"]),
                                                       VehicleNo = dr["VehicleNo"].ToString(),
                                                       VehicleBrand = dr["VehicleBrand"].ToString(),
                                                       VehicleModel = ConversionHelper.ToInt32(dr["VehicleModel"]),
                                                       VehicleColor = dr["VehicleColor"].ToString(),
                                                       VehicleKmsRan = ConversionHelper.ToDecimal(dr["VehicleKmsRan"].ToString()),
                                                       VehicleTypeId = ConversionHelper.ToInt32(dr["VehicleTypeId"]),
                                                       ComplaintId = dr["ComplaintId"].ToString(),
                                                       ExpectedDelivery = ConversionHelper.ToDateTime(dr["ExpectedDelivery"].ToString()),
                                                       TotalPrice = ConversionHelper.ToDecimal(dr["TotalPrice"].ToString()),
                                                       DeliveryStatus = dr["DeliveryStatus"].ToString(),
                                                   }).ToList();
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;
        }
        public ResultArgs FetchVehicleData(DataValue dv)
        {
            sSQL = "[dbo].[usp_FetchVehicleDetails]";
            //sSQL = "[dbo].[FetchVehicleDetails]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region Delete Vehicle
        /// <summary>
        /// To delete vehicle details from db
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ResultArgs DeleteVehicle(DataValue dv)
        {
            sSQL = "[dbo].[usp_DeleteVehicle]";
            return objHandler.ExecuteCommand(sSQL, dv, false, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region FetchVehicleTypes
        /// <summary>
        /// To fetch vehicle type
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public VehicleCommanModel FetchVehicleTypes(DataValue dv)
        {
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchVehicle(dv);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {
                    customer.vehicleTypesList = (from DataRow dr in result.DataSource.Table.Rows
                                                 select new VehicleTypes
                                                 {

                                                     VehicleTypeId = ConversionHelper.ToInt32(dr["VehicleTypeId"]),
                                                     VehicleType = dr["VehicleType"].ToString()
                                                 }).ToList();
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;

        }
        public ResultArgs FetchVehicle(DataValue dv)
        {
            sSQL = "[dbo].[usp_FetchVehicleType]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
    }
}
