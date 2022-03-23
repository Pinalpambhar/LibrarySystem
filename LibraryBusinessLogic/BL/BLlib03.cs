using LibraryBusinessLogic.DBManagement;
using LibraryBusinessLogic.Models;
using System.Data;

namespace LibraryBusinessLogic.BL
{
    public class BLlib03
    {
        #region Private Members
        private string _query;
        #endregion Private Members

        #region Public Methods
        /// <summary>
        /// Retrieve All Book Types
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBookType()
        {
            try
            {
                DataTable _dtBookType;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b03f01,
                                                     b03f02
                                               FROM 
                                                     lib03");
                    _dtBookType = objDBManager.GetData(_query);
                }
                return _dtBookType;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve Specified Book Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetBookTypeById(int id)
        {
            try
            {
                DataTable _dtBookType;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b03f01,
                                                     b03f02
                                               FROM 
                                                     lib03
                                               WHERE 
                                                    b03f01 = @b03f01");

                    objDBManager.WhereParams.Add("b03f01", id);
                    _dtBookType = objDBManager.GetDataWithParams(_query);
                }
                return _dtBookType;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Insert New Book Type
        /// </summary>
        /// <param name="objLib03"></param>
        /// <returns></returns>
        public string InsertBookType(lib03 objLib03)
        {
            try
            {
                int _result;
                using (DBManager objDBManager = new DBManager())
                {
                    objDBManager.Params.Add("b03f02", objLib03.b03f02);
                    _result = objDBManager.ExecQueryWithParams("lib03");
                }
                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "BookType Inserted Successfully";
                }
                else
                {
                    return "BookType not Inserted";
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update Existing Book Type
        /// </summary>
        /// <param name="objLib03"></param>
        /// <returns></returns>
        public string UpdateBookType(lib03 objLib03)
        {
            try
            {
                int _result;
                using (DBManager objDBManager = new DBManager())
                {
                    objDBManager.WhereParams.Add("b03f01", objLib03.b03f01);
                    if (objLib03.b03f02 != null)
                        objDBManager.Params.Add("b03f02", objLib03.b03f02);

                    _result = objDBManager.ExecQueryWithParams("lib03", "b03f01=@b03f01");
                }
                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "BookType Updated Successfully";
                }
                else
                {
                    return "BookType not Updated";
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete specified Book Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteBookTypeById(int id)
        {
            try
            {
                int _result;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"Delete                                                 
                                               FROM 
                                                     lib03
                                               WHERE 
                                                    b03f01 = @b03f01");

                    objDBManager.WhereParams.Add("b03f01", id);
                    _result = objDBManager.DeleteDataWithParams(_query);
                }

                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "BookType Deleted Successfully";
                }
                else
                {
                    return "BookType not Deleted";
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
