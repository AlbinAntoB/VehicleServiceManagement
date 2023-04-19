namespace VehicleSeviceManagement.DbEngine
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using VehicleSeviceManagement.Framework;
    using VehicleSeviceManagement.Framework.Helper;

    /// <summary>
    /// Sql server Handler
    /// </summary>
    public interface ISqlServerHanlder
    {
       
        ResultArgs FetchData(string query, EnumCommand.DataSource dataSourceType, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic);

        ResultArgs ExecuteCommand(string query, DataValue dv = null, bool getlastinsert_ID = false, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic, string spOutput = "@ReturnValue");

        object ExecuteScalar(string query, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic);

        Task<ResultArgs> FetchDataAsync(string query, EnumCommand.DataSource dataSourceType, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic);

        Task<ResultArgs> ExecuteCommandAsync(string query, DataValue dv = null, bool getlastinsert_ID = false, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic, string spOutput = "@ReturnValue");

        Task<object> ExecuteScalarAsync(string query, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic);

        T FetchDatabyClass<T>(string query, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic);

        Task<XmlReader> FetchXmlReader(string query, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic);
    }

    /// <summary>
    /// Sql server Handler
    /// </summary>
    /// <seealso cref="DynamicForms.DBEngine.ISqlServerHanlder" />
    public class SQLServerHandler : ISqlServerHanlder
    {
        /// <summary>
        /// The connection
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="SQLServerHandler"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public SQLServerHandler(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("Connection"));
        }

        /// <summary>
        /// This method helps in opening the MYSQL Connection
        /// </summary>
        /// <returns>
        /// Returning mysql connection
        /// </returns>
        /// <exception cref="MySQLException">Problem in opening sql connection</exception>
        /// <exception cref="InvalidOperationException">The connection is open already</exception>
        private SqlConnection OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Open();
            }
            catch (InvalidOperationException ex)
            {
                new ErrorLog().WriteLog(ex);
            }
            catch (Exception ex)
            {
                new ErrorLog().WriteLog(ex);
            }

            return connection;
        }

        /// <summary>
        /// This method helps in closing the connection
        /// </summary>
        private void CloseConnection()
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        /// <summary>
        /// Get the .Net Data Type and return the corresponding SqlDbType Datatype
        /// </summary>
        /// <param name="fieldType">.Net DataType Enumerator</param>
        /// <returns>
        /// SqlDbType
        /// </returns>
        private SqlDbType GetSQLFieldType(EnumCommand.DataType fieldType)
        {
            switch (fieldType)
            {
                case EnumCommand.DataType.Boolean:
                    { return SqlDbType.Bit; }
                case EnumCommand.DataType.Byte:
                    { return SqlDbType.TinyInt; }
                case EnumCommand.DataType.Char:
                    { return SqlDbType.VarChar; }
                case EnumCommand.DataType.DateTime:
                    { return SqlDbType.DateTime; }
                case EnumCommand.DataType.TimeSpan:
                    { return SqlDbType.Timestamp; }
                case EnumCommand.DataType.Money:
                    { return SqlDbType.Money; }
                case EnumCommand.DataType.Double:
                case EnumCommand.DataType.Decimal:
                    { return SqlDbType.Decimal; }
                case EnumCommand.DataType.Single:
                    { return SqlDbType.Real; }
                case EnumCommand.DataType.Int:
                case EnumCommand.DataType.Int32:
                    { return SqlDbType.Int; }
                case EnumCommand.DataType.Int16:
                    { return SqlDbType.SmallInt; }
                case EnumCommand.DataType.Int64:
                    { return SqlDbType.BigInt; }
                case EnumCommand.DataType.Text:
                    { return SqlDbType.Text; }
                case EnumCommand.DataType.Xml:
                    { return SqlDbType.Xml; }
                case EnumCommand.DataType.Varchar:
                    { return SqlDbType.VarChar; }
                case EnumCommand.DataType.nVarchar:
                    { return SqlDbType.NVarChar; }
                case EnumCommand.DataType.ByteArray:
                    { return SqlDbType.VarBinary; }
                default:
                    { return SqlDbType.VarChar; }
            }
        }

        /// <summary>
        /// Execute the Insert,Update,Delete Query
        /// </summary>
        /// /// <param name="query">The Insert,Update or Delete Query</param>
        /// <param name="dv">DataValue Object</param>
        /// <param name="getlastinsert_ID">LAST_INSERT_ID if set to true
        /// bind last insert id in the result args</param>
        /// <param name="sqlType">Type of the SQL.</param>
        /// <param name="spOutput">The sp output.</param>
        /// <returns>
        /// Number of Rows Affected by the Query
        /// greater than 1 --&gt; successZ
        /// 0 --&gt; failure
        /// -1  --&gt; table referred(delete mode)
        /// -2 --&gt; record referred(delete mode)
        /// </returns>
        public ResultArgs ExecuteCommand(string query, DataValue dv = null, bool getlastinsert_ID = false, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic, string spOutput = "@ReturnValue")
        {
            ResultArgs result = new ResultArgs();
            result.Success = false;
            SqlCommand Command = null;
            SqlConnection Con = OpenConnection();
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    //throw new ArgumentNullException("Query is empty", "ExecuteCommand(DataValue dv, string query");
                    using (ErrorLog objlog = new ErrorLog())
                    {
                        objlog.WriteLog("Error Handler " + "ExecuteScalar(DataValue,string) " + query + " Query is empty!");
                    }
                }
                else
                {
                    Command = SetSqlCommand(dv, query, Con, sqlType);
                    Command.CommandTimeout = 0;
                    if (getlastinsert_ID)
                    {
                        SqlParameter returnParameter = new SqlParameter();
                        if (spOutput != null && sqlType == EnumCommand.SQLType.SQLStoredProcedure)
                        {
                            returnParameter = Command.Parameters.Add(spOutput, SqlDbType.Int);
                            if (sqlType == EnumCommand.SQLType.SQLStatic)
                                returnParameter.Direction = ParameterDirection.ReturnValue;
                            else
                                returnParameter.Direction = ParameterDirection.Output;
                            result.RowsAffected = Command.ExecuteNonQuery();
                            result.RowUniqueId = (int)returnParameter.Value;
                            result.ReturnValue = returnParameter.Value;
                        }
                        else
                        {
                            result.RowsAffected = Command.ExecuteNonQuery();
                            Command.CommandText = "SELECT @@identity";
                            Command.CommandType = CommandType.Text;
                            result.RowUniqueId = Command.ExecuteScalar().ToString();
                        }
                    }
                    else
                    {
                        result.RowsAffected = Command.ExecuteNonQuery();
                    }
                    result.Success = true;
                }
            }
            catch (InvalidOperationException ex)
            {
                //throw new InvalidOperationException("Problem in Execute Command " + iex.Message, iex);
                result.RowsAffected = ex.Message.ToLower().Contains("foreign keys") ? -1 : ex.Message.ToLower().Contains("integrity constraint") ? -2 : 0;
                new ErrorLog().WriteLog(ex);
            }
            catch (Exception ex)
            {
                //integrity constraint - This will be thrown when you try to insert NULL value to non nullable column
                //foreign key/reference constraint - This is for foreign key constraint.

                result.RowsAffected = ex.Message.ToLower().Contains("integrity constraint") ? -1 : ex.Message.ToLower().Contains("reference constraint") ? -2 : 0;
                new ErrorLog().WriteLog(ex);
            }
            finally
            {
                if (Command != null)
                    Command.Dispose();
                Command = null;
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        /// Execute Scalar Query
        /// </summary>
        /// <param name="query">The Select Query</param>
        /// <param name="dv">DataValue Object</param>
        /// <param name="sqlType">Type of the SQL.</param>
        /// <returns>
        /// If The Execute Scalar Returns the Null, the function will return
        /// the empty string otherwise the value
        /// </returns>
        public object ExecuteScalar(string query, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic)
        {
            object ScalarValue = new object();
            SqlCommand Command = null;
            SqlConnection Con = OpenConnection();
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    using (ErrorLog objlog = new ErrorLog())
                    {
                        objlog.WriteLog("Error Handler " + "ExecuteScalar(DataValue,string) " + query + " Query is empty!");
                    }
                }
                if (dv == null)
                    Command = new SqlCommand(query, Con);
                else
                    Command = SetSqlCommand(dv, query, Con, sqlType);
                Object obj = Command.ExecuteScalar();
                if (obj != null)
                    ScalarValue = obj.ToString();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Command != null)
                    Command.Dispose();
                Command = null;
                CloseConnection();
            }
            return ScalarValue;
        }

        /// <summary>
        /// Execute the Select Query
        /// </summary>
        /// <param name="query">The Select Query</param>
        /// <param name="dataSourceType">Type of the data source.</param>
        /// <param name="dv">DataValue Object</param>
        /// <param name="sqlType">Type of the SQL.</param>
        /// <returns>
        /// DataTable with the records
        /// </returns>
        public ResultArgs FetchData(string query, EnumCommand.DataSource dataSourceType = EnumCommand.DataSource.DataTable, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic)
        {
            ResultArgs result = new ResultArgs();
            result.Success = true;
            SqlDataAdapter Adapter;
            SqlCommand Command = null;
            DataSet ds = new DataSet();
            SqlConnection Con = OpenConnection();
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    //throw new ArgumentNullException("Query is empty", "FetchData(DataValue dv, string query)");
                    using (ErrorLog objlog = new ErrorLog())
                    {
                        result.Success = false;
                    }
                }
                else
                {
                    if (dv == null)
                        Command = new SqlCommand(query, Con);
                    else
                        Command = SetSqlCommand(dv, query, Con, sqlType);
                    Command.CommandTimeout = 0;
                    result.dataSource = null;
                    try
                    {
                        if (Con.State == ConnectionState.Open && Command != null)
                        {
                            switch (dataSourceType)
                            {
                                case EnumCommand.DataSource.DataSet:
                                    {
                                        Adapter = new SqlDataAdapter(Command);
                                        if (result.dataSource == null) result.dataSource = new DataSet();
                                        result.RowsAffected = Adapter.Fill(result.dataSource as DataSet);
                                        result.Success = true;
                                        break;
                                    }
                                case EnumCommand.DataSource.DataView:
                                    {
                                        Adapter = new SqlDataAdapter(Command);
                                        if (result.dataSource == null) result.dataSource = new DataTable();
                                        result.RowsAffected = Adapter.Fill(result.dataSource as DataTable);
                                        result.dataSource = ((DataTable)result.dataSource).DefaultView;
                                        result.Success = true;
                                        break;
                                    }
                                case EnumCommand.DataSource.DataReader:
                                    {
                                        result.dataSource = Command.ExecuteReader();
                                        result.RowsAffected = ((SqlDataReader)result.dataSource).RecordsAffected;
                                        result.Success = true;
                                        break;
                                    }

                                case EnumCommand.DataSource.Scalar:
                                    {
                                        result.dataSource = Command.ExecuteScalar();
                                        if (result.dataSource != null)
                                        {
                                            result.RowsAffected = 1;
                                            result.Success = true;
                                        }
                                        else
                                        {
                                            result.RowsAffected = 0;
                                            result.Success = true;
                                        }

                                        break;
                                    }

                                default:
                                    {
                                        Adapter = new SqlDataAdapter(Command);
                                        if (result.dataSource == null) result.dataSource = new DataTable();
                                        result.RowsAffected = Adapter.Fill(result.dataSource as DataTable);
                                        result.Success = true;
                                        break;
                                    }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                            result.Success = false;
                        new ErrorLog().WriteLog(ex);
                    }
                    finally
                    {
                        CloseConnection();
                    }

                    if (result.Success)
                    {
                        result.DataSource.Data = result.dataSource;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                new ErrorLog().WriteLog(ex);
            }
            finally
            {
                if (Command != null)
                    Command.Dispose();
                Command = null;
                CloseConnection();
            }
            return result;
        }

        public T FetchDatabyClass<T>(string query, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic)
        {
            T result;
            SqlCommand Command = null;
            SqlConnection Con = OpenConnection();
            try
            {
                if (dv == null)
                    Command = new SqlCommand(query, Con);
                else
                    Command = SetSqlCommand(dv, query, Con, sqlType);

                Command.CommandTimeout = 0;
                try
                {
                    if (Con.State == ConnectionState.Open && Command != null)
                    {
                        using (var reader = Command.ExecuteXmlReader())
                        {
                            result = DataMapper.XmlReaderToObject<T>(reader);
                        }
                    }
                    else
                    {
                        result = default(T);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Command != null)
                    Command.Dispose();
                Command = null;
                CloseConnection();
            }
            return result;
        }

        public async Task<XmlReader> FetchXmlReader(string query, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic)
        {
            XmlReader result;
            SqlCommand Command = null;
            SqlConnection Con = OpenConnection();
            try
            {
                if (dv == null)
                    Command = new SqlCommand(query, Con);
                else
                    Command = SetSqlCommand(dv, query, Con, sqlType);
                try
                {
                    if (Con.State == ConnectionState.Open && Command != null)
                    {
                        using (var reader = await Command.ExecuteXmlReaderAsync())
                        {
                            result = reader;
                        }
                        //result = await Command.ExecuteXmlReaderAsync();
                    }
                    else
                    {
                        result = default(XmlReader);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Command != null)
                    Command.Dispose();
                Command = null;
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        /// Add the parameter name, value and data type to the MySql Command Object
        /// </summary>
        /// <param name="dv">DataValue Object</param>
        /// <param name="query">The Insert,Update,Delete or Select Query</param>
        /// <param name="connection">The connection.</param>
        /// <param name="sqlType">Type of the SQL.</param>
        /// <returns>
        /// MySql Command
        /// </returns>
        private SqlCommand SetSqlCommand(DataValue dv, string query, SqlConnection connection, EnumCommand.SQLType sqlType)
        {
            SqlCommand Command = new SqlCommand(query, connection);
            if (dv != null)
            {
                string Param = "";
                string FieldName = "";
                Command.CommandType = (sqlType == EnumCommand.SQLType.SQLStoredProcedure) ? CommandType.StoredProcedure : CommandType.Text;
                foreach (DataValueBase dvBase in dv)
                {
                    try
                    {
                        FieldName = dvBase.FieldName;
                        Param = GetParameter(query, FieldName, sqlType);
                        if (Param != string.Empty)
                        {
                            SqlParameter Parameter = new SqlParameter(Param, GetSQLFieldType(dvBase.FieldDataType));
                            if (dvBase.FieldDataType == EnumCommand.DataType.ByteArray)
                            {
                                if (string.IsNullOrEmpty(dvBase.FieldValue))
                                    Parameter.Value = DBNull.Value;
                                else
                                    Parameter.Value = Encoding.ASCII.GetBytes(dvBase.FieldValue);
                            }
                            else
                            {
                                if (dvBase.FieldValue != string.Empty)
                                    Parameter.Value = dvBase.FieldValue;
                                else
                                    Parameter.Value = DBNull.Value;
                            }
                            Command.Parameters.Add(Parameter);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return Command;
        }

        /// <summary>
        /// Check a parameter is available in the query
        /// </summary>
        /// <param name="query">The Select,Insert,Update or Delete Query</param>
        /// <param name="fieldName">The Filed Name</param>
        /// <param name="sqlType">Type of the SQL.</param>
        /// <returns>
        /// if the query contains the field,it return the filed name other wise returns the empty
        /// </returns>
        private string GetParameter(string query, string fieldName, EnumCommand.SQLType sqlType)
        {
            string param = "@" + fieldName;
            if (sqlType == EnumCommand.SQLType.SQLStatic)
            {
                param = "@" + fieldName.ToUpper();
                param = query.ToUpper().Contains(param) ? param : string.Empty;
            }
            return param;
        }

        /// <summary>
        /// Execute the Insert,Update,Delete Query
        /// </summary>
        /// /// <param name="query">The Insert,Update or Delete Query</param>
        /// <param name="dv">DataValue Object</param>
        /// <param name="getlastinsert_ID">LAST_INSERT_ID if set to true
        /// bind last insert id in the result args</param>
        /// <param name="sqlType">Type of the SQL.</param>
        /// <param name="spOutput">The sp output.</param>
        /// <returns>
        /// Number of Rows Affected by the Query
        /// greater than 1 --&gt; successZ
        /// 0 --&gt; failure
        /// -1  --&gt; table referred(delete mode)
        /// -2 --&gt; record referred(delete mode)
        /// </returns>
        public async Task<ResultArgs> ExecuteCommandAsync(string query, DataValue dv = null, bool getlastinsert_ID = false, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic, string spOutput = "@ReturnValue")
        {
            ResultArgs result = new ResultArgs();
            result.Success = false;
            SqlCommand Command = null;
            SqlConnection Con = OpenConnection();
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    //throw new ArgumentNullException("Query is empty", "ExecuteCommand(DataValue dv, string query");
                    using (ErrorLog objlog = new ErrorLog())
                    {
                        objlog.WriteLog("Error Handler " + "ExecuteScalar(DataValue,string) " + query + " Query is empty!");
                    }
                }
                else
                {
                    Command = SetSqlCommand(dv, query, Con, sqlType);
                    Command.CommandTimeout = 0;
                    if (getlastinsert_ID)
                    {
                        SqlParameter returnParameter = new SqlParameter();
                        if (spOutput != null && sqlType == EnumCommand.SQLType.SQLStoredProcedure)
                        {
                            returnParameter = Command.Parameters.Add(spOutput, SqlDbType.Int);
                            if (sqlType == EnumCommand.SQLType.SQLStatic)
                                returnParameter.Direction = ParameterDirection.ReturnValue;
                            else
                                returnParameter.Direction = ParameterDirection.Output;
                            result.RowsAffected = await Command.ExecuteNonQueryAsync().ConfigureAwait(false);
                            result.RowUniqueId = (int)returnParameter.Value;
                            result.ReturnValue = returnParameter.Value;
                        }
                        else
                        {
                            result.RowsAffected = Command.ExecuteNonQuery();
                            Command.CommandText = "SELECT @@identity";
                            Command.CommandType = CommandType.Text;
                            result.RowUniqueId = Command.ExecuteScalarAsync().ToString();
                        }
                    }
                    else
                    {
                        result.RowsAffected = await Command.ExecuteNonQueryAsync();
                    }
                    result.Success = true;
                }
            }
            catch (InvalidOperationException ex)
            {
                //throw new InvalidOperationException("Problem in Execute Command " + iex.Message, iex);
                result.RowsAffected = ex.Message.ToLower().Contains("foreign keys") ? -1 : ex.Message.ToLower().Contains("integrity constraint") ? -2 : 0;
                throw ex;
            }
            catch (Exception ex)
            {
                //integrity constraint - This will be thrown when you try to insert NULL value to non nullable column
                //foreign key/reference constraint - This is for foreign key constraint.

                result.RowsAffected = ex.Message.ToLower().Contains("integrity constraint") ? -1 : ex.Message.ToLower().Contains("reference constraint") ? -2 : 0;
                throw ex;
            }
            finally
            {
                if (Command != null)
                    Command.Dispose();
                Command = null;
                CloseConnection();
            }
            return result;
        }

        /// <summary>
        /// Execute Scalar Query
        /// </summary>
        /// <param name="query">The Select Query</param>
        /// <param name="dv">DataValue Object</param>
        /// <param name="sqlType">Type of the SQL.</param>
        /// <returns>
        /// If The Execute Scalar Returns the Null, the function will return
        /// the empty string otherwise the value
        /// </returns>
        public async Task<object> ExecuteScalarAsync(string query, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic)
        {
            object ScalarValue = new object();
            SqlCommand Command = null;
            SqlConnection Con = OpenConnection();
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    using (ErrorLog objlog = new ErrorLog())
                    {
                        objlog.WriteLog("Error Handler " + "ExecuteScalar(DataValue,string) " + query + " Query is empty!");
                    }
                }
                if (dv == null)
                    Command = new SqlCommand(query, Con);
                else
                    Command = SetSqlCommand(dv, query, Con, sqlType);
                Object obj = await Command.ExecuteScalarAsync();
                if (obj != null)
                    ScalarValue = obj.ToString();
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Command != null)
                    Command.Dispose();
                Command = null;
                CloseConnection();
            }
            return ScalarValue;
        }

        /// <summary>
        /// Execute the Select Query
        /// </summary>
        /// <param name="query">The Select Query</param>
        /// <param name="dataSourceType">Type of the data source.</param>
        /// <param name="dv">DataValue Object</param>
        /// <param name="sqlType">Type of the SQL.</param>
        /// <returns>
        /// DataTable with the records
        /// </returns>
        public async Task<ResultArgs> FetchDataAsync(string query, EnumCommand.DataSource dataSourceType = EnumCommand.DataSource.DataTable, DataValue dv = null, EnumCommand.SQLType sqlType = EnumCommand.SQLType.SQLStatic)
        {
            ResultArgs result = new ResultArgs();
            result.Success = true;
            SqlDataAdapter Adapter;
            SqlCommand Command = null;
            DataSet ds = new DataSet();
            SqlConnection Con = OpenConnection();
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    //throw new ArgumentNullException("Query is empty", "FetchData(DataValue dv, string query)");
                    using (ErrorLog objlog = new ErrorLog())
                    {
                        result.Success = false;
                    }
                }
                else
                {
                    if (dv == null)
                        Command = new SqlCommand(query, Con);
                    else
                        Command = SetSqlCommand(dv, query, Con, sqlType);

                    Command.CommandTimeout = 0;

                    result.dataSource = null;
                    try
                    {
                        if (Con.State == ConnectionState.Open && Command != null)
                        {
                            switch (dataSourceType)
                            {
                                case EnumCommand.DataSource.DataSet:
                                    {
                                        Adapter = new SqlDataAdapter(Command);
                                        if (result.dataSource == null) result.dataSource = new DataSet();
                                        result.RowsAffected = Adapter.Fill(result.dataSource as DataSet);
                                        result.Success = true;
                                        break;
                                    }
                                case EnumCommand.DataSource.DataView:
                                    {
                                        Adapter = new SqlDataAdapter(Command);
                                        if (result.dataSource == null) result.dataSource = new DataTable();
                                        result.RowsAffected = Adapter.Fill(result.dataSource as DataTable);
                                        result.dataSource = ((DataTable)result.dataSource).DefaultView;
                                        result.Success = true;
                                        break;
                                    }
                                case EnumCommand.DataSource.DataReader:
                                    {
                                        result.dataSource = await Command.ExecuteReaderAsync();
                                        result.RowsAffected = ((SqlDataReader)result.dataSource).RecordsAffected;
                                        result.Success = true;
                                        break;
                                    }
                                case EnumCommand.DataSource.Scalar:
                                    {
                                        result.dataSource = await Command.ExecuteScalarAsync();
                                        if (result.dataSource != null)
                                        {
                                            result.RowsAffected = 1;
                                            result.Success = true;
                                        }
                                        else
                                        {
                                            result.RowsAffected = 0;
                                            result.Success = true;
                                        }

                                        break;
                                    }

                                default:
                                    {
                                        Adapter = new SqlDataAdapter(Command);
                                        if (result.dataSource == null) result.dataSource = new DataTable();
                                        result.RowsAffected = Adapter.Fill(result.dataSource as DataTable);
                                        result.Success = true;
                                        break;
                                    }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        throw ex;
                    }
                    finally
                    {
                        CloseConnection();
                    }

                    if (result.Success)
                    {
                        result.DataSource.Data = result.dataSource;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                throw ex;
            }
            finally
            {
                if (Command != null)
                    Command.Dispose();
                Command = null;
                CloseConnection();
            }
            return result;
        }
    }
}