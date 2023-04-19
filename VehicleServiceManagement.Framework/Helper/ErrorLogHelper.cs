/***********************************************************************************************************
 * Created by       : Justine
 * Created On       : 14 Mar 2018
 *
 *
 * Reviewed By      :
 * Reviewed On      :
 *
 * Purpose          : This is to handle parameters passing from one layer to other layers
 ***********************************************************************************************************/

using System;
using System.IO;

namespace VehicleSeviceManagement.Framework.Helper
{ /// <summary>
  /// Summary description for ErrorLog
  /// </summary>
    public class ErrorLog : IDisposable
    {
        #region Properties

        private static string LogFilePath = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\ErrorLog", "\\", DateTime.Today.Year + "\\", DateTime.Today.Month);

        private string LogFileName = string.Empty;
        private string LogAPIFileName = string.Empty;

        #endregion Properties

        public ErrorLog()
        {
            //check if the directory exists
            if (!Directory.Exists(LogFilePath))
            {
                Directory.CreateDirectory(LogFilePath);
            }
            LogFileName = string.Concat(LogFilePath, "\\", "Log_", DateTime.Today.ToShortDateString().Replace("/", "_"), ".log");
            LogAPIFileName = string.Concat(LogFilePath, "\\", "APILog_", DateTime.Today.ToShortDateString().Replace("/", "_"), ".log");
        }

        /// <summary>
        /// This method is to write the passed error message and other details of error occurence
        /// </summary>
        /// <param name="sMessage">string - Error message</param>
        ///
        public void WriteLog(string sMessage)
        {
            try
            {
                StreamWriter sw = File.AppendText(LogFileName);
                sw.WriteLine("Date/Time : " + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                sw.WriteLine("Message   : " + sMessage);
                sw.Close();
            }
            catch (Exception ex)
            {
                string ErrMsg = ex.Message;
            }
        }

        public void WriteLog(Exception ex)
        {
            try
            {
                StreamWriter sw = File.AppendText(LogFileName);
                sw.WriteLine("-----------------------------------------------------------------------------------------");
                sw.WriteLine("Date/Time  :" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                sw.WriteLine("Source/MSG :" + ex.Source + " / " + ex.Message);
                sw.WriteLine("StackTrace :" + ex.StackTrace);
                sw.WriteLine("-----------------------------------------------------------------------------------------");
                sw.Close();
            }
            catch (Exception exlog)
            {
                string ErrMsg = exlog.Message;
            }
        }

        /// <summary>
        /// Method used to write the exception passed an an arugement to targetted text file
        /// in a new line
        /// </summary>
        /// <param name="ex"></param>
        public void WriteLog(string className, string methodName, string query, string errMessage)
        {
            try
            {
                StreamWriter sw = File.AppendText(LogFileName);
                sw.WriteLine("-----------------------------------------------------------------------------------------");
                sw.WriteLine("Date/Time  :" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                sw.WriteLine("ClassName  :" + className);
                sw.WriteLine("MethodName :" + methodName);
                if (!string.IsNullOrEmpty(query))
                    sw.WriteLine("Query      :" + query);
                sw.WriteLine("Message    :" + errMessage);
                sw.WriteLine("-----------------------------------------------------------------------------------------");
                sw.Close();
            }
            catch (Exception exMsg)
            {
                string sError = exMsg.Message;
            }
            WriteLog("-----------------------------------------------------------------------------------------");
        }

        public void WriteAPILog(string Module, string Error)
        {
            try
            {
                StreamWriter sw = File.AppendText(LogAPIFileName);
                sw.WriteLine("-----------------------------------------------------------------------------------------");
                sw.WriteLine("Date/Time  :" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString());
                sw.WriteLine("Module  :" + Module);
                if (!string.IsNullOrEmpty(Error))
                    sw.WriteLine("Error :" + Error);
                sw.WriteLine("-----------------------------------------------------------------------------------------");
                sw.Close();
            }
            catch (Exception exMsg)
            {
                string sError = exMsg.Message;
            }
            WriteLog("-----------------------------------------------------------------------------------------");
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}