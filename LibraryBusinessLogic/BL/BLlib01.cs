using LibraryBusinessLogic.DBManagement;
using LibraryBusinessLogic.Models;
using System;
using System.Data;

namespace LibraryBusinessLogic.BL
{
    public class BLlib01
    {
        #region Private Members
        private string _query;
        Cryptography objCryptography = new Cryptography();
        #endregion Private Members

        #region Public Methods
        /// <summary>
        /// Retrieve All Users Data
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllUsers()
        {
            try
            {
                DataTable _dtUsersData;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b01f01,
                                                     b01f02,
                                                     b01f03,
                                                     b01f04,
                                                     b01f05,
                                                     b01f06,
                                                     b01f07,
                                                     b01f08
                                               FROM 
                                                     lib01");
                    _dtUsersData = objDBManager.GetData(_query);
                }
                foreach (DataRow row in _dtUsersData.Rows)
                {
                    row["b01f06"] = objCryptography.Decrypt(row["b01f06"].ToString());
                }
                return _dtUsersData;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve Specified Users Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetUserById(int id)
        {
            try
            {
                DataTable _dtUserData;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b01f01,
                                                     b01f02,
                                                     b01f03,
                                                     b01f04,
                                                     b01f05,
                                                     b01f06,
                                                     b01f07,
                                                     b01f08
                                               FROM 
                                                     lib01
                                               WHERE 
                                                    b01f01 = @b01f01");

                    objDBManager.WhereParams.Add("b01f01", id);
                    _dtUserData = objDBManager.GetDataWithParams(_query);

                }
                foreach (DataRow row in _dtUserData.Rows)
                {
                    row["b01f06"] = objCryptography.Decrypt(row["b01f06"].ToString());
                }
                return _dtUserData;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Insert New User
        /// </summary>
        /// <param name="objLib01"></param>
        /// <returns></returns>
        public string InsertUser(lib01 objLib01)
        {
            try
            {
                int _result;
                string _todayDate = DateTime.Today.ToString("yyyy-MM-dd");
                using (DBManager objDBManager = new DBManager())
                {
                    objDBManager.Params.Add("b01f02", objLib01.b01f02);
                    objDBManager.Params.Add("b01f03", objLib01.b01f03);
                    objDBManager.Params.Add("b01f04", objLib01.b01f04);
                    objDBManager.Params.Add("b01f05", objLib01.b01f05);
                    objDBManager.Params.Add("b01f06", objCryptography.Encrypt(objLib01.b01f06));
                    objDBManager.Params.Add("b01f08", _todayDate);
                    _result = objDBManager.ExecQueryWithParams("lib01");
                }

                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "User Inserted Successfully";
                }
                else
                {
                    return "User not Inserted";
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update Existing User
        /// </summary>
        /// <param name="objLib01"></param>
        /// <returns></returns>
        public string UpdateUser(lib01 objLib01)
        {
            try
            {
                int _result;
                string _todayDate = DateTime.Today.ToString("yyyy-MM-dd");
                using (DBManager objDBManager = new DBManager())
                {
                    objDBManager.WhereParams.Add("b01f01", objLib01.b01f01);
                    if (objLib01.b01f02 != null)
                        objDBManager.Params.Add("b01f02", objLib01.b01f02);
                    if (objLib01.b01f03 != null)
                        objDBManager.Params.Add("b01f03", objLib01.b01f03);
                    if (objLib01.b01f04 != null)
                        objDBManager.Params.Add("b01f04", objLib01.b01f04);
                    if (objLib01.b01f05 != null)
                        objDBManager.Params.Add("b01f05", objLib01.b01f05);
                    if (objLib01.b01f06 != null)
                        objDBManager.Params.Add("b01f06", objLib01.b01f06);
                    objDBManager.Params.Add("b01f08", _todayDate);
                    _result = objDBManager.ExecQueryWithParams("lib01", "b01f01=@b01f01");
                }
                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "User Updated Successfully";
                }
                else
                {
                    return "User not Updated";
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete specified user data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteUserById(int id)
        {
            try
            {
                int _result;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"Delete                                                 
                                               FROM 
                                                     lib01
                                               WHERE 
                                                    b01f01 = @b01f01");

                    objDBManager.WhereParams.Add("b01f01", id);
                    _result = objDBManager.DeleteDataWithParams(_query);                
                }
                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "User Deleted Successfully";
                }
                else
                {
                    return "User not Deleted";
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion Public Methods
    }
}
