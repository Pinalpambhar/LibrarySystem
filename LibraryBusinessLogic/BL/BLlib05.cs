using LibraryBusinessLogic.DBManagement;
using LibraryBusinessLogic.Models;
using MySql.Data.MySqlClient;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;

namespace LibraryBusinessLogic.BL
{
    public delegate string BookOperation(lib05 objLib05);
    public class BLlib05 : DatabaseConfig
    {
        public static event BookOperation eventBookOperations;

        #region Private Members
        private string _query;
        #endregion Private Members

        #region Private Method
        private List<lib02> GetBookStockdata(int id)
        {
            var dbFactory = GetConnection();
            List<lib02> lstlib02 = new List<lib02>();
            using (var db = dbFactory.Open())
            {
                lstlib02 = db.Select(db.From<lib02>()
                                     .Where(x => x.b02f01 == id)
                                     .Select(x => new { x.b02f08, x.b02f09 }));
            }
            return lstlib02;
        }

        private List<DateTime> GetBookReturnDate(int bookId, int userId)
        {
            var dbFactory = GetConnection();
            List<DateTime> lstlib05 = new List<DateTime>();
            using (var db = dbFactory.Open())
            {
                lstlib05 = db.Select<DateTime>(db.From<lib05>()
                                     .Where(x => x.b05f01 == bookId && x.b05f02 == userId)
                                     .Select(x => x.b05f05));
            }
            return lstlib05;
        }
        #endregion Private Method

        #region Public Method
        /// <summary>
        /// Retrieve All Rented Books Record
        /// </summary>
        /// <returns></returns>s
        public DataTable GetAllRents()
        {
            try
            {
                DataTable _dtRentsData;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b05f01,
                                                     b05f02,
                                                     b05f03,
                                                     b05f04,
                                                     b05f05,
                                                     b05f06
                                               FROM 
                                                     lib05");
                    _dtRentsData = objDBManager.GetData(_query);
                }
                return _dtRentsData;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve Specified Rent Record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetRentById(int id)
        {
            try
            {
                DataTable _dtRentData;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b05f01,
                                                     b05f02,
                                                     b05f03,
                                                     b05f04,
                                                     b05f05,
                                                     b05f06
                                               FROM 
                                                     lib05
                                               WHERE 
                                                    b05f01 = @b05f01");

                    objDBManager.WhereParams.Add("b05f01", id);
                    _dtRentData = objDBManager.GetDataWithParams(_query);
                }
                return _dtRentData;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve Specified Rent Record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetRentByUserId(int userId)
        {
            try
            {
                DataTable _dtRentData;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b05f01,
                                                     b05f02,
                                                     b05f03,
                                                     b05f04,
                                                     b05f05,
                                                     b05f06
                                               FROM 
                                                     lib05
                                               WHERE 
                                                    b05f02 = @b05f02");

                    objDBManager.WhereParams.Add("b05f02", userId);
                    _dtRentData = objDBManager.GetDataWithParams(_query);
                }
                return _dtRentData;
            }
            catch
            {
                throw;
            }
        }

        public string UpdateRent(int bookId, int userId)
        {
            try
            {
                var dbFactory = GetConnection();

                //Updating Issue Record
                using (var db = dbFactory.Open())
                {
                    int _result = db.UpdateOnly(() => new lib05 { b05f06 = 0 }, where: x => x.b05f01 == bookId && x.b05f02 == userId);

                    //if _result is 1 then query executed successully
                    if (_result == 1)
                    {
                        List<lib02> _stockData = GetBookStockdata(bookId);

                        db.UpdateOnly(() => new lib02 { b02f08 = _stockData[0].b02f08 + 1, b02f09 = _stockData[0].b02f09 - 1 }, where: x => x.b02f01 == bookId);

                        //if Late Return Apply Penalty
                        List<DateTime> _returnDate = GetBookReturnDate(bookId, userId);
                        TimeSpan t = DateTime.Now.Subtract(_returnDate[0]);

                        if (t.TotalDays > 0)
                        {
                            lib06 objLib06 = new lib06();
                            BLlib06 objBLlib06 = new BLlib06();

                            objLib06.b06f01 = userId;
                            objLib06.b06f02 = bookId;
                            objLib06.b06f04 = Convert.ToInt32(t.Days * 50);
                            objLib06.b06f05 = "Late Return";

                            objBLlib06.InsertPenalty(objLib06);
                        }
                        return "Book Returned Successfully";
                    }
                    else
                    {
                        return "Book Returned fails!";
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// invokes delegate
        /// </summary>
        /// <param name="objLib05"></param>
        /// <returns></returns>
        public static string BookOperations(lib05 objLib05)
        {
            BLlib05 objBLlib05 = new BLlib05();
            eventBookOperations += objBLlib05.InsertRent;

            return eventBookOperations.Invoke(objLib05);

        }

        /// <summary>
        /// Insert New Rented Book
        /// </summary>
        /// <param name="objLib05"></param>
        /// <returns></returns>
        public string InsertRent(lib05 objLib05)
        {
            eventBookOperations -= UpdateIssueBookStock;
            try
            {
                int _result;
                DateTime _issueDate = DateTime.Now;

                //calculating Return Date
                DateTime _returnDate = _issueDate.AddDays(objLib05.b05f03);


                using (DBManager objDBManager = new DBManager())
                {
                    objDBManager.Params.Add("b05f01", objLib05.b05f01);
                    objDBManager.Params.Add("b05f02", objLib05.b05f02);
                    objDBManager.Params.Add("b05f03", objLib05.b05f03);
                    objDBManager.Params.Add("b05f04", _issueDate);
                    objDBManager.Params.Add("b05f05", _returnDate);
                    _result = objDBManager.ExecQueryWithParams("lib05");  
                }
                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    eventBookOperations += UpdateIssueBookStock;
                    eventBookOperations.Invoke(objLib05);
                    return "Book Issued Success!";
                }
                else
                {
                    return "Something went wrong!";
                }
            }
            catch (MySqlException Ex)
            {
                if (Ex.Number == 1062)
                {
                    return "Data already exist";
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Update Book Stock
        /// </summary>
        /// <param name="objLib05"></param>
        /// <returns></returns>
        public string UpdateIssueBookStock(lib05 objLib05)
        {
            var dbFactory = GetConnection();
            List<lib02> _stockData = GetBookStockdata(objLib05.b05f01);
            try
            {
                int _result;
                //Updating Book Stock
                using (var db = dbFactory.Open())
                {
                    _result = db.UpdateOnly(() => new lib02 { b02f08 = _stockData[0].b02f08 - 1, b02f09 = _stockData[0].b02f09 + 1 }, where: x => x.b02f01 == objLib05.b05f01);
                }

                if (_result == 1)
                {
                    return "Book Issued Success!";
                }
                else
                {
                    return "Something went wrong!";
                }
            }
            catch
            {
                throw;
            }

        }
        #endregion
    }
}
