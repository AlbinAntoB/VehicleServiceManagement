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

namespace VehicleSeviceManagement.Framework
{
    using VehicleSeviceManagement.Framework.Helper;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DataValueBase
    {
        private string _FieldName;
        private string _FieldValue;
        private EnumCommand.DataType _DataType;

        public DataValueBase(string fieldName, string fieldValue, EnumCommand.DataType dataType)
        {
            this._FieldName = fieldName;
            this._FieldValue = fieldValue;
            this._DataType = dataType;
        }
       
        public string FieldName
        {
            set { _FieldName = value; }
            get { return _FieldName; }
        }

        public string FieldValue
        {
            set { _FieldValue = value; }
            get { return _FieldValue; }
        }

       
        public EnumCommand.DataType FieldDataType
        {
            set { _DataType = value; }
            get { return _DataType; }
        }
    }
    /// <summary>
    /// Store the Values in the List object 
    /// </summary>
    public class DataValue
    {
        private List<DataValueBase> DataItem = new List<DataValueBase>();
        public int Count
        {
            get { return DataItem.Count; }
        }
        public DataValueBase this[int index]
        {
            get { return DataItem[index]; }
        }
        public void Add(string fieldName, string fieldValue, EnumCommand.DataType dataType)
        {
            DataItem.Add(new DataValueBase(fieldName, fieldValue, dataType));
        }
         

        public void Add(string fieldName, object fieldValue, EnumCommand.DataType dataType = EnumCommand.DataType.Varchar)
        {
            Add(fieldName, fieldValue.ToString(), dataType);
        }
        public DataValueBase GetItem(int index)
        {
            return DataItem[index];
        }

        // Added by Justine on 23-Nov-2017 - Get Index by Field name  
        public DataValueBase GetItem(string byKey)
        {

            int index = 0;
            try
            {
                index = DataItem.FindIndex(a => a.FieldName == byKey);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }

            return DataItem[index];
        }
        public void Clear()
        {
            DataItem.Clear();
        }
        public void Remove(DataValueBase dv)
        {
            DataItem.Remove(dv);
        }
        public void RemoveItem(int index)
        {
            DataItem.RemoveAt(index);
        }
        public void RemoveItem(string byKey)
        {
            int index = 0;
            try
            {
                index = DataItem.FindIndex(a => a.FieldName == byKey);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            DataItem.RemoveAt(index);
        }
        public IEnumerator GetEnumerator()
        {
            return DataItem.GetEnumerator();
        }
    }
}
