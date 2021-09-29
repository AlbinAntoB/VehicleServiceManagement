using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using VehicleServiceManagement.Models;
using VehicleSeviceManagement.DbEngine;
using VehicleSeviceManagement.Framework;
using VehicleSeviceManagement.Framework.Helper;

namespace VehicleServiceManagement.Data
{
    public interface IVehicleRepository
    {
        // To Insert an Cutomer register Details
        ResultArgs InsertCutomerRegistertion(DataValue dv);
        // To check the UserName and password And Getting Customer Details
        CustomerCommanModel CheckUserName(DataValue dv);
        //To Fetch Customer Comman Complaints
        CustomerCommanModel FetchComplaints(DataValue dv);
        // To Insert an Complaints
        ResultArgs InsertComplaints(DataValue dv);
        //To Fetch Vehicle Types
        CustomerCommanModel FetchVehicleTypes(DataValue dv);
        //To Fetch Customer Pariticular Complaints
        CustomerCommanModel FetchCustomerComplaints(DataValue dv);
        //To Delete an Complaints
        ResultArgs DeleteComplaints(DataValue dv);
        // To Fetch An Report
        CustomerCommanModel FetchanReport(DataValue dv);
        //To Fetch Customers Vehicle Details
        CustomerCommanModel FetchVehicleDetails(DataValue dv);
        //To Delete an Vehicle Details
        ResultArgs DeleteVehicle(DataValue dv);
        // To Insert an VehicleDetails
        ResultArgs InsertVehicleDetails(DataValue dv);
    }
    public class VehicleRepository: IVehicleRepository
    {
        //  Creating an Object for Comman Model
        CustomerCommanModel customer = new CustomerCommanModel();
        #region Common for SqlServer injecting
        // Declaring  String varible for Query or Stored procedure
        private string sSQL;
      
        // Creating an object for SqlSqrver Handler
        private ISqlServerHanlder objHandler;
        // Injecting  a SQlServerHandler by constructor
        public VehicleRepository(ISqlServerHanlder sqlServerHanlder)
        {
            objHandler = sqlServerHanlder;
        }
        #endregion
        #region Customer Registertion
        // To Implements of  Cutomer register Details

        public ResultArgs InsertCutomerRegistertion(DataValue dv)
        {
            sSQL = "[dbo].[usp_InsertCustomerInfo]";
            return objHandler.ExecuteCommand(sSQL, dv, true, EnumCommand.SQLType.SQLStoredProcedure);

        }
        #endregion
        #region Check UserName And password
        // To check username and password and getting Customer Details
        public CustomerCommanModel CheckUserName(DataValue dv)
        {
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchCustomerInfo(dv);
                if(result.DataSource.Table!=null && result.DataSource.Table.Rows.Count>0)
                {
                    customer.customermodelList=(from DataRow dr in result.DataSource.Table.Rows 
                                                select new CustomerModel
                                                {
                                                       UserRoll = Convert.ToInt32(dr["UserRoll"]),
                                                       CustomerId = Convert.ToInt32(dr["CustomerId"]),
                                                       CustomerName = dr["CustomerName"].ToString(),
                                                }).ToList();
                }
            }
            catch(Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;
        }
        public ResultArgs FetchCustomerInfo(DataValue dv)
        {
            sSQL = "[dbo].[usp_CheckUserName]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }

        #endregion  
        #region FetchVehicleTypes
        public CustomerCommanModel FetchVehicleTypes(DataValue dv)
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

                                                        VehicleTypeId = Convert.ToInt32(dr["VehicleTypeId"]),
                                                        VehicleType = dr["VehicleType"].ToString()
                                                    }).ToList();
                }
            }
            catch(Exception ex)
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
        #region FetchComplaints
        public CustomerCommanModel FetchComplaints(DataValue dv)
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
                                                             ComplaintId = Convert.ToInt32(dr["ComplaintId"]),
                                                             Complaints = dr["Complaints"].ToString(),
                                                             Price = Convert.ToDecimal(dr["Price"]),
                                                             VehicleTypeId = Convert.ToInt32(dr["VehicleTypeId"]),
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
        public ResultArgs InsertComplaints(DataValue dv)
        {
            sSQL = "[dbo].[usp_InsertComplaints]";
            return objHandler.ExecuteCommand(sSQL, dv, true, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region Fetch Pariticular Complaints
        public CustomerCommanModel FetchCustomerComplaints(DataValue dv)
        {
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchParicularComplaint(dv);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {
                    customer.customerComplaintsList = (from DataRow dr in result.DataSource.Table.Rows
                                                         select new CustomerComplaints
                                                         {
                                                             ComplaintId = Convert.ToInt32(dr["ComplaintId"]),
                                                             Complaints = dr["Complaints"].ToString(),
                                                             Price = Convert.ToDecimal(dr["Price"]),
                                                             VehicleTypeId = Convert.ToInt32(dr["VehicleTypeId"]),
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
        public ResultArgs DeleteComplaints(DataValue dv)
        {
            sSQL = "[dbo].[usp_DeleteComplaints]";
            return objHandler.ExecuteCommand(sSQL, dv, false, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region To Fetch An Report
        // To Fetch an report details
        public CustomerCommanModel FetchanReport(DataValue dv)
        {
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchReportInfo(dv);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {
                    customer.reportList= (from DataRow dr in result.DataSource.Table.Rows
                                                  select new report
                                                  {
                                                      
                                                      CustomerName = dr["CustomerName"].ToString(),
                                                      Email = dr["Email"].ToString(),
                                                      MobileNo = dr["MobileNo"].ToString(),
                                                      Address=dr["Address"].ToString(),
                                                      VehicleNo=dr["VehicleNo"].ToString(),
                                                      VehicleBrand = dr["VehicleBrand"].ToString(),
                                                      VehicleModel = Convert.ToInt32(dr["VehicleModel"]),
                                                      VehicleColor= dr["VehicleColor"].ToString(),
                                                      VehicleKmsRan= Convert.ToDecimal(dr["TotalPrice"].ToString()),
                                                      ExpectedDelivery =Convert.ToDateTime(dr["ExpectedDelivery"].ToString()),
                                                      TotalPrice=Convert.ToDecimal(dr["TotalPrice"].ToString()),
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
        #region To Fetch An Vehcile Details
        public CustomerCommanModel FetchVehicleDetails(DataValue dv)
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
                                               VehicleId= Convert.ToInt32(dr["VehicleId"]),
                                               VehicleNo = dr["VehicleNo"].ToString(),
                                               VehicleBrand = dr["VehicleBrand"].ToString(),
                                               VehicleModel = Convert.ToInt32(dr["VehicleModel"]),
                                               VehicleColor = dr["VehicleColor"].ToString(),
                                               VehicleKmsRan = Convert.ToDecimal(dr["TotalPrice"].ToString()),
                                               ComplaintId = dr["ComplaintId"].ToString(),
                                               ExpectedDelivery = Convert.ToDateTime(dr["ExpectedDelivery"].ToString()),
                                               TotalPrice = Convert.ToDecimal(dr["TotalPrice"].ToString()),
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
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region Delete Vehicle
        public ResultArgs DeleteVehicle(DataValue dv)
        {
            sSQL = "[dbo].[usp_DeleteVehicle]";
            return objHandler.ExecuteCommand(sSQL, dv, false, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region Insert an VehicleDetails
        public ResultArgs InsertVehicleDetails(DataValue dv)
        {
            sSQL = "[dbo].[usp_InsertVehicleDetails]";
            return objHandler.ExecuteCommand(sSQL, dv, true, EnumCommand.SQLType.SQLStoredProcedure);

        }
        #endregion
    }
}
