using LibraryBusinessLogic.DBManagement;
using LibraryBusinessLogic.Models;
using System;
using System.Data;

namespace LibraryBusinessLogic.BL
{
    public class BLlib02
    {
        #region Private Members
        private string _query;
        #endregion Private Members

        #region Public Methods
        /// <summary>
        /// Retrieve All Books Data
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBooks()
        {
            try
            {
                DataTable _dtBookssData;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b02f01,
                                                     b02f02,
                                                     b02f03,
                                                     b02f04,
                                                     b02f05,
                                                     b02f06,
                                                     b02f07,
                                                     b02f08,
                                                     b02f09,
                                                     b02f10,
                                                     b02f11,
                                                     b02f12
                                               FROM 
                                                     lib02");
                    _dtBookssData = objDBManager.GetData(_query);
                }
                return _dtBookssData;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve Specified Book Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetBookById(int id)
        {
            try
            {
                DataTable _dtBookData;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b02f01,
                                                     b02f02,
                                                     b02f03,
                                                     b02f04,
                                                     b02f05,
                                                     b02f06,
                                                     b02f07,
                                                     b02f08,
                                                     b02f09,
                                                     b02f10,
                                                     b02f11,
                                                     b02f12
                                               FROM 
                                                     lib02
                                               WHERE 
                                                    b02f01 = @b02f01");

                    objDBManager.WhereParams.Add("b02f01", id);
                    _dtBookData = objDBManager.GetDataWithParams(_query);
                }
                return _dtBookData;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Insert New Book
        /// </summary>
        /// <param name="lib02"></param>
        /// <returns></returns>
        public string InsertBook(lib02 objLib02)
        {
            try
            {
                int _result;
                string _todayDate = DateTime.Today.ToString("yyyy-MM-dd");
                using (DBManager objDBManager = new DBManager())
                {
                    objDBManager.Params.Add("b02f02", objLib02.b02f02);
                    objDBManager.Params.Add("b02f03", objLib02.b02f03);
                    objDBManager.Params.Add("b02f04", objLib02.b02f04);
                    objDBManager.Params.Add("b02f05", objLib02.b02f05);
                    objDBManager.Params.Add("b02f06", objLib02.b02f06);
                    objDBManager.Params.Add("b02f07", objLib02.b02f07);
                    objDBManager.Params.Add("b02f08", objLib02.b02f08);
                    objDBManager.Params.Add("b02f10", objLib02.b02f10);
                    objDBManager.Params.Add("b02f11", objLib02.b02f11);
                    objDBManager.Params.Add("b02f12", _todayDate);

                    _result = objDBManager.ExecQueryWithParams("lib02");
                }
                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "Book Inserted Successfully";
                }
                else
                {
                    return "Book not Inserted";
                }

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update Existing Book
        /// </summary>
        /// <param name="objLib02"></param>
        /// <returns></returns>
        public string UpdateBook(lib02 objLib02)
        {
            try
            {
                int _result;
                string _todayDate = DateTime.Today.ToString("yyyy-MM-dd");
                using (DBManager objDBManager = new DBManager())
                {
                    objDBManager.Params.Add("b02f12", _todayDate);
                    objDBManager.WhereParams.Add("b02f01", objLib02.b02f01);
                    if (objLib02.b02f02 != null)
                        objDBManager.Params.Add("b02f02", objLib02.b02f02);

                    if (objLib02.b02f03 != null)
                        objDBManager.Params.Add("b02f03", objLib02.b02f03);

                    if (objLib02.b02f04 != null)
                        objDBManager.Params.Add("b02f04", objLib02.b02f04);

                    if (objLib02.b02f05 != null)
                        objDBManager.Params.Add("b02f05", objLib02.b02f05);

                    if (objLib02.b02f06 != null)
                        objDBManager.Params.Add("b02f06", objLib02.b02f06);

                    if (objLib02.b02f07 != 0)
                        objDBManager.Params.Add("b02f07", objLib02.b02f07);

                    if (objLib02.b02f08 != 0)
                        objDBManager.Params.Add("b02f08", objLib02.b02f08);

                    if (objLib02.b02f07 != 0 && objLib02.b02f08 != 0)
                        objDBManager.Params.Add("b02f09", (objLib02.b02f07 - objLib02.b02f08));

                    if (objLib02.b02f10 != 0)
                        objDBManager.Params.Add("b02f10", objLib02.b02f10);

                    if (objLib02.b02f11 != null)
                        objDBManager.Params.Add("b02f11", objLib02.b02f11);

                    _result = objDBManager.ExecQueryWithParams("lib02", "b02f01=@b02f01");
                }
                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "Book Updated Successfully";
                }
                else
                {
                    return "Book not Updated";
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete specified Book data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteBookById(int id)
        {
            try
            {
                int _result;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"Delete                                                 
                                               FROM 
                                                     lib02
                                               WHERE 
                                                    b02f01 = @b02f01");

                    objDBManager.WhereParams.Add("b02f01", id);
                    _result = objDBManager.DeleteDataWithParams(_query);
                }
                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "Book Deleted Successfully";
                }
                else
                {
                    return "Book not Deleted";
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
