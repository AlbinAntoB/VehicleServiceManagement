/***********************************************************************************************************
 * Created by       : Justine
 * Created On       : 01 Dec 2017
 *
 * Reviewed By      :
 * Reviewed On      :
 *
 * Purpose          : To have Conversion methods that handles NULL as well with proper parsing
 ***********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using VehicleSeviceManagement.Framework.Helper;

namespace VehicleSeviceManagement.Framework.Helper
{
    public static class ConversionHelper
    {
        public static string FormatSQL(string objString)
        {
            return (string.IsNullOrEmpty(objString)) ? "NULL" : ("'" + objString + "'");
        }

        public static string ToString(object objString)
        {
            return objString != null ? Convert.ToString(objString) : string.Empty;
        }

        public static string ToDate(string sSource)
        {
            System.Globalization.DateTimeFormatInfo dateInfoDTMS = new System.Globalization.DateTimeFormatInfo();
            dateInfoDTMS.ShortDatePattern = "dd-MM-yyyy HH:mm:ss";

            DateTime dtValue = new DateTime();
            string sDest = string.Empty;

            try
            {
                dtValue = Convert.ToDateTime( sSource, dateInfoDTMS);
                sDest = dtValue.ToString("MM/dd/yyyy");
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }

            return sDest;
        }

        public static string TosqlDate(object objDate)
        {
            System.Globalization.DateTimeFormatInfo dateInfoDTMS = new System.Globalization.DateTimeFormatInfo();
            dateInfoDTMS.ShortDatePattern = "dd-MM-yyyy HH:mm:ss";

            DateTime dtValue = new DateTime();
            string sDest = string.Empty;

            try
            {
                dtValue = Convert.ToDateTime(objDate.ToString(), dateInfoDTMS);
                sDest = dtValue.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }

            return sDest;
        }
        public static string TosqlDatetime(object objDate)
        {
            System.Globalization.DateTimeFormatInfo dateInfoDTMS = new System.Globalization.DateTimeFormatInfo();
            dateInfoDTMS.ShortDatePattern = "dd-MM-yyyy HH:mm:ss";

            DateTime dtValue = new DateTime();
            string sDest = string.Empty;

            try
            {
                dtValue = Convert.ToDateTime(objDate.ToString(), dateInfoDTMS);
                sDest = dtValue.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }

            return sDest;
        }


        public static DateTime ToDateTime(string sSource, string Dateformat = "MM/dd/yyyy")
        {
            DateTime dtValue = new DateTime();

            try
            {
                if (!DateTime.TryParse(sSource, out dtValue))
                    dtValue = DateTime.Now;
                //dtValue = DateTime.ParseExact(sSource, Dateformat, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }

            return dtValue;
        }

        public static DateTime ToDateTime(string sSource)
        {
            DateTime dtValue;
            if (!DateTime.TryParse(sSource, out dtValue))
                dtValue = DateTime.Now;
            return dtValue;
        }

        public static DateTime ToDateTime(object objDate)
        {
            DateTime dtValue;
            if (!DateTime.TryParse(ToString(objDate), out dtValue))
                dtValue = DateTime.Now;
            return dtValue;
        }

        /// <summary>
        /// this method is used to return Null if object value is empty -- 03/16/2020
        /// </summary>
        /// <param name="objDate"></param>
        /// <returns></returns>
        public static DateTime? ToDateTimeNull(object objDate)
        {
            if (!DateTime.TryParse(ToString(objDate), out DateTime dtValue))
                return null;
            else
                return dtValue;
        }

        public static Int16 ToInt16(string sSource)
        {
            Int16 iValue = default(Int16);
            Int16.TryParse(sSource, out iValue);
            return iValue;
        }

        public static Int16 ToInt16(object objSource)
        {
            Int16 iValue = default(Int16);
            Int16.TryParse(ToString(objSource), out iValue);
            return iValue;
        }

        public static Int32 ToInt32(string sSource)
        {
            Int32 iValue = default(Int32);
            Int32.TryParse(sSource, out iValue);
            return iValue;
        }

        public static Int32 ToInt32(object objSource)
        {
            Int32 iValue = default(Int32);
            Int32.TryParse(ToString(objSource), out iValue);
            return iValue;
        }

        public static Int64 ToInt64(object objSource)
        {
            Int64 iValue = default(Int64);
            Int64.TryParse(ToString(objSource), out iValue);
            return iValue;
        }

        public static int ToInteger(string sSource)
        {
            int iValue = default(int);
            int.TryParse(sSource, out iValue);
            return iValue;
        }

        public static int ToInteger(object obj)
        {
            int iValue = default(int);
            int.TryParse(ToString(obj), out iValue);
            return iValue;
        }

        public static int ToInteger(bool istrue)
        {
            int iValue = default(int);
            iValue = Convert.ToInt32(istrue);
            return iValue;
        }

        public static decimal ToDecimal(string sSource)
        {
            decimal dValue = default(decimal);
            decimal.TryParse(sSource, out dValue);
            return dValue;
        }

        public static decimal ToDecimal(object obj)
        {
            decimal dValue = default(decimal);
            bool isDec = decimal.TryParse(ToString(obj), out dValue);
            return dValue;
        }

        public static double ToDouble(string sSource)
        {
            double dValue = default(double);
            double.TryParse(sSource, out dValue);
            return dValue;
        }

        public static double ToDouble(object obj)
        {
            double dValue = default(double);
            double.TryParse(ToString(obj), out dValue);
            return dValue;
        }

        public static float ToFloat(string sSource)
        {
            float dValue = default(float);
            float.TryParse(sSource, out dValue);
            return dValue;
        }

        public static float ToFloat(object obj)
        {
            float dValue = default(float);
            float.TryParse(ToString(obj), out dValue);
            return dValue;
        }

        public static Boolean ToBoolean(string sSource)
        {
            Boolean dValue = default(Boolean);
            Boolean.TryParse(sSource, out dValue);
            return dValue;
        }

        public static Boolean ToBoolean(object obj)
        {
            Boolean dValue = default(Boolean);
            Boolean.TryParse(ToString(obj), out dValue);
            return dValue;
        }

        /// <summary>
        ///  this method is used to return Null if object value is empty -- 03/16/2020
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Boolean? ToBooleanNull(object obj)
        {
            if (!Boolean.TryParse(ToString(obj), out bool dValue))
                return null;
            else
                return dValue;
        }

        public static byte Tobyte(string v)
        {
            byte dValue = default(byte);
            byte.TryParse(ToString(v), out dValue);
            return dValue;
        }
    }
}