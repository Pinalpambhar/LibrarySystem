using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LibraryBusinessLogic.DBManagement
{
    public class DBManager : DatabaseConfig, IDisposable
    {
        #region Private Member
        MySqlConnection _objConnect;
        bool _dispose = false;
        #endregion Private Member

        #region Public Member
        public Dictionary<string, object> Params = null;     //Parameters dictionary
        public Dictionary<string, object> WhereParams = null; ////Where Condition Parameters dictionary
        #endregion Public Member

        #region Constructor
        public DBManager()
        {
            _objConnect = new MySqlConnection(connectionstring);
            Params = new Dictionary<string, object>();
            WhereParams = new Dictionary<string, object>();
        }

        ~DBManager()
        {
            Dispose(true);
        }
        #endregion Constructor

        #region Public Methods
        /// <summary>
        /// Open Connection
        /// </summary>
        public void OpenConnection()
        {
            if (_objConnect.State != ConnectionState.Open)
                _objConnect.Open();
        }

        /// <summary>
        /// Close Connection
        /// </summary>
        public void CloseConnection()
        {
            if (_objConnect.State != ConnectionState.Closed)
                _objConnect.Close();
        }

        /// <summary>
        /// Execute Select query and get Result
        /// </summary>
        /// <param name="qry">Select statement</param>
        /// <returns>DataTable result</returns>
        public DataTable GetData(string query)
        {
            DataTable _dt = new DataTable();
            try
            {
                OpenConnection();

                using (MySqlDataAdapter da = new MySqlDataAdapter(query, _objConnect))
                {
                    da.Fill(_dt);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
            return _dt;
        }

        /// <summary>
        /// Execute Select query using Parameters
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable GetDataWithParams(string query)
        {
            try
            {
                DataTable _dt;
                OpenConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, _objConnect))
                {
                    foreach (string key in WhereParams.Keys)
                    {
                        cmd.Parameters.Add(new MySqlParameter("@" + key, WhereParams[key]));
                    }
                    using (MySqlDataAdapter objAdapter = new MySqlDataAdapter(cmd))
                    {
                        _dt = new DataTable();
                        objAdapter.Fill(_dt);
                    }
                }
                return _dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                ClearParams();
                CloseConnection();
            }
        }

        /// <summary>
        /// Execute SQL Query With Command Parameters usin MySqlTransaction(Insert, Update)
        /// </summary>
        /// <param name="tbl_name">string tablename</param>
        /// <param name="condition">optional string where condition for update operation</param>
        /// <returns></returns>
        public int ExecQueryWithParams(string tableName, string condition = null)
        {
            int _result = 0;
            try
            {
                OpenConnection();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = _objConnect;

                    StringBuilder query = new StringBuilder();
                    StringBuilder query_val = new StringBuilder();

                    if (condition == null)
                    {
                        query.Append("INSERT INTO " + tableName + "(");
                        query_val.Append(" VALUES(");

                        foreach (string key in Params.Keys)
                        {
                            query.Append(key + ",");
                            query_val.Append("@" + key + ",");
                            cmd.Parameters.Add(new MySqlParameter("@" + key, Params[key]));
                        }
                        query = query.Remove(query.Length - 1, 1).Append(")");
                        query_val = query_val.Remove(query_val.Length - 1, 1).Append(")");

                        cmd.CommandText = query.ToString() + query_val.ToString();
                    }
                    else
                    {
                        query.Append("UPDATE " + tableName + " SET ");
                        foreach (string key in Params.Keys)
                        {
                            query.Append(key + "=@" + key + ",");
                            cmd.Parameters.Add(new MySqlParameter("@" + key, Params[key]));
                        }
                        foreach (string key in WhereParams.Keys)
                        {
                            cmd.Parameters.Add(new MySqlParameter("@" + key, WhereParams[key]));
                        }

                        query = query.Remove(query.Length - 1, 1).Append(" WHERE " + condition);
                        cmd.CommandText = query.ToString();
                    }
                    query.Clear();
                    query_val.Clear();
                    _result = cmd.ExecuteNonQuery();

                }
            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
                ClearParams();
            }
            return _result;
        }

        /// <summary>
        /// Execute Delete query using Parameters
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int DeleteDataWithParams(string query)
        {
            int _result = 0;
            try
            {
                OpenConnection();
                using (MySqlCommand cmd = new MySqlCommand(query, _objConnect))
                {
                    foreach (string key in WhereParams.Keys)
                    {
                        cmd.Parameters.Add(new MySqlParameter("@" + key, WhereParams[key]));
                    }
                    _result = cmd.ExecuteNonQuery();
                }
                return _result;
            }
            catch
            {
                throw;
            }
            finally
            {
                ClearParams();
                CloseConnection();
            }
        }

        public void ClearParams()
        {
            Params.Clear();
            WhereParams.Clear();
        }

        public void Dispose()
        {
            Dispose(_dispose);
            GC.SuppressFinalize(this);
        }
        #endregion Public Methods

        #region Private Methods
        private void Destroy()
        {
            if (_objConnect != null && _objConnect.State == ConnectionState.Open)
            {
                _objConnect.Close();
                _objConnect.Dispose();
            }
            _objConnect = null;
        }
        #endregion Private Method

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                Destroy();
                _dispose = true;
            }
        }
    }
}
