using LibraryBusinessLogic.DBManagement;
using LibraryBusinessLogic.Models;
using System.Data;

namespace LibraryBusinessLogic.BL
{
    public class BLlib04
    {
        #region Private Members
        private string _query;
        #endregion Private Members

        #region Public Methods
        /// <summary>
        /// Retrieve All Publication
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllPublication()
        {
            try
            {
                DataTable _dtPublication;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b04f01,
                                                     b04f02
                                               FROM 
                                                     lib04");
                    _dtPublication = objDBManager.GetData(_query);
                }
                return _dtPublication;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve Specified Publication
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetPublicationById(int id)
        {
            try
            {
                DataTable _dtPublication;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b04f01,
                                                     b04f02
                                               FROM 
                                                     lib04
                                               WHERE 
                                                    b04f01 = @b04f01");

                    objDBManager.WhereParams.Add("b04f01", id);
                    _dtPublication = objDBManager.GetDataWithParams(_query);
                }
                return _dtPublication;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Insert New Publication
        /// </summary>
        /// <param name="objLib04"></param>
        /// <returns></returns>
        public string InsertPublication(lib04 objLib04)
        {
            try
            {
                int _result;
                using (DBManager objDBManager = new DBManager())
                {
                    objDBManager.Params.Add("b04f02", objLib04.b04f02);
                    _result = objDBManager.ExecQueryWithParams("lib04");
                }

                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "Publication Inserted Successfully";
                }
                else
                {
                    return "Publication not Inserted";
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update Existing Publication
        /// </summary>
        /// <param name="objLib04"></param>
        /// <returns></returns>
        public string UpdatePublication(lib04 objLib04)
        {
            try
            {
                int _result;
                using (DBManager objDBManager = new DBManager())
                {
                    objDBManager.WhereParams.Add("b04f01", objLib04.b04f01);
                    if (objLib04.b04f02 != null)
                        objDBManager.Params.Add("b04f02", objLib04.b04f02);

                    _result = objDBManager.ExecQueryWithParams("lib04", "b04f01=@b04f01");
                }

                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "Publication Updated Successfully";
                }
                else
                {
                    return "Publication not Updated";
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete specified Publication
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeletePublicationById(int id)
        {
            try
            {
                int _result;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"Delete                                                 
                                               FROM 
                                                     lib04
                                               WHERE 
                                                    b04f01 = @b04f01");

                    objDBManager.WhereParams.Add("b04f01", id);
                    _result = objDBManager.DeleteDataWithParams(_query);                
                }

                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "Publication Deleted Successfully";
                }
                else
                {
                    return "Publication not Deleted";
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
