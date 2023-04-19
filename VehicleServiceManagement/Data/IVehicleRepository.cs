namespace VehicleServiceManagement.Data
{
    using System;
    using System.Data;
    using System.Linq;
    using VehicleServiceManagement.Models;
    using VehicleSeviceManagement.DbEngine;
    using VehicleSeviceManagement.Framework;
    using VehicleSeviceManagement.Framework.Helper;
    public interface IVehicleRepository
    {
        // To Insert an Cutomer register Details
        ResultArgs InsertCutomerRegistertion(DataValue dv);
        // To check the UserName and password And Getting Customer Details
        CustomerCommanModel CheckUserName(DataValue dv);
        // To Change password or forgetten password
        ResultArgs UpdatePassword(DataValue dv);
        //To Fetch Customer Count
        CustomerCommanModel FetchCustomerCount(DataValue dv);
        //To Insert Gst
        ResultArgs InsertGst(DataValue dv);
        //To fetch Gst Details
        CustomerCommanModel FetchGst(DataValue dv);

        //To fetch Gst Details
        CustomerCommanModel FetchCustomerReport(DataValue dv);
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
        /// <summary>
        /// Injecting  a SQlServerHandler by constructor
        /// </summary>
        /// <param name="sqlServerHanlder"></param>
        public VehicleRepository(ISqlServerHanlder sqlServerHanlder)
        {
            objHandler = sqlServerHanlder;
        }
        #endregion
        #region Customer Registertion
        /// <summary>
        /// To Implements of  Cutomer register Details
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ResultArgs InsertCutomerRegistertion(DataValue dv)
        {
            sSQL = "[dbo].[usp_InsertCustomerInfo]";
            return objHandler.ExecuteCommand(sSQL, dv, true, EnumCommand.SQLType.SQLStoredProcedure);

        }
        #endregion
        #region Check UserName And password
        /// <summary>
        /// To check username and password and getting Customer Details
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
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
                                                       UserRoll = ConversionHelper.ToInt32(dr["UserRoll"]),
                                                       CustomerId = ConversionHelper.ToInt32(dr["CustomerId"]),
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
        #region Update password
        /// <summary>
        /// To update password
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ResultArgs UpdatePassword(DataValue dv)
        {

            sSQL = "[dbo].[usp_Changepassword]";
            return objHandler.ExecuteCommand(sSQL, dv, true, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region FetchanCustomer Count Report
        /// <summary>
        /// To fetch an customer report
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public CustomerCommanModel FetchCustomerCount(DataValue dv)
        {
            AdminReport adminReport = new AdminReport();
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchCustomerTotalCount(dv);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {
                    adminReport.TotalCount = ConversionHelper.ToInt32(result.DataSource.Table.Rows[0][0]);
                    adminReport.VehicleCount = ConversionHelper.ToInt32(result.DataSource.Table.Rows[1][0]);
                    adminReport.ComplaintsCount = ConversionHelper.ToInt32(result.DataSource.Table.Rows[2][0]);
                    adminReport.FeedbackCount = ConversionHelper.ToInt32(result.DataSource.Table.Rows[3][0]);
                }
                customer.adminReport= adminReport;
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;
        }
        public ResultArgs FetchCustomerTotalCount(DataValue dv)
        {
            sSQL = "[dbo].[FetchCustomerCount]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region Insert Gst price
        /// <summary>
        /// To save the gst price
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public ResultArgs InsertGst(DataValue dv)
        {
            sSQL = "[dbo].[InsertGst]";
            return objHandler.ExecuteCommand(sSQL, dv, true, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region Fecth Gst
        /// <summary>
        /// To fecth the gst price from db
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public CustomerCommanModel FetchGst(DataValue dv)
        {
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchGstDetails(dv);
                if (result.DataSource.Table != null && result.DataSource.Table.Rows.Count > 0)
                {
                    customer.GstList = (from DataRow dr in result.DataSource.Table.Rows
                                                       select new Gst
                                                       {
                                                           GstId = ConversionHelper.ToInt32(dr["GstId"]),
                                                           AboveThousand = ConversionHelper.ToDecimal(dr["AboveThousand"].ToString()),
                                                           LessThousand = ConversionHelper.ToDecimal(dr["LessThousand"]),
                                                       }).ToList();
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;
        }
        public ResultArgs FetchGstDetails(DataValue dv)
        {
            sSQL = "[dbo].[FetchGst]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataTable, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
        #region Fecth Customer Report
        /// <summary>
        /// To fecth Customer Report
        /// </summary>
        /// <param name="dv"></param>
        /// <returns></returns>
        public CustomerCommanModel FetchCustomerReport(DataValue dv)
        {
            CustomerCommanModel customer = new CustomerCommanModel();
            ResultArgs result = new ResultArgs();
            try
            {
                result = FetchCustomerReports(dv);
                if (result.DataSource.TableSet != null)
                {
                    if (result.DataSource.TableSet != null && result.DataSource.TableSet.Tables[0].Rows.Count > 0)
                    {
                        customer.customermodelList = (from DataRow dr in result.DataSource.TableSet.Tables[0].Rows
                                                      select new CustomerModel
                                                      {
                                                          CustomerName = dr["CustomerName"].ToString(),
                                                          Email = dr["Email"].ToString(),
                                                          MobileNo = dr["MobileNo"].ToString(),
                                                          Address = dr["Address"].ToString()
                                                      }).ToList();
                    }
                    if (result.DataSource.TableSet.Tables[1].Rows.Count > 0)
                    {
                        customer.Count = ConversionHelper.ToInt64(result.DataSource.TableSet.Tables[1].Rows[0][0]);
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            return customer;
        }
        public ResultArgs FetchCustomerReports(DataValue dv)
        {
            sSQL = "[dbo].[uspCustomerReport]";
            return objHandler.FetchData(sSQL, EnumCommand.DataSource.DataSet, dv, EnumCommand.SQLType.SQLStoredProcedure);
        }
        #endregion
    }
}
