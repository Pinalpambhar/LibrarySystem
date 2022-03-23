using LibraryBusinessLogic.DBManagement;
using LibraryBusinessLogic.Models;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;

namespace LibraryBusinessLogic.BL
{
    public class BLlib06 : DatabaseConfig
    {
        #region Private Members
        private string _query;
        #endregion Private Members

        #region Private Method
        private List<lib02> GetBookdata(int bookId)
        {
            var dbFactory = GetConnection();
            List<lib02> lstlib02 = new List<lib02>();
            using (var db = dbFactory.Open())
            {
                lstlib02 = db.Select<lib02>(db.From<lib02>()
                                     .Where(x => x.b02f01 == bookId)
                                     .Select(x => new { x.b02f02, x.b02f10 }));
            }
            return lstlib02;
        }
        #endregion Private Method

        #region Public Methods
        /// <summary>
        /// Retrieve All Penalty Data
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllPenalties()
        {
            try
            {
                DataTable _dtPenaltyData;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b06f01,
                                                     b06f02,
                                                     b06f03,
                                                     b06f04,
                                                     b06f05,
                                                     b06f06
                                               FROM 
                                                     lib06");
                    _dtPenaltyData = objDBManager.GetData(_query);
                }
                return _dtPenaltyData;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve Specified Users Penalty Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetPenaltyById(int id)
        {
            try
            {
                DataTable _dtPenaltyData;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"SELECT 
                                                     b06f01,
                                                     b06f02,
                                                     b06f03,
                                                     b06f04,
                                                     b06f05,
                                                     b06f06
                                               FROM 
                                                     lib06
                                               WHERE 
                                                    b06f01 = @b06f01");

                    objDBManager.WhereParams.Add("b06f01", id);
                    _dtPenaltyData = objDBManager.GetDataWithParams(_query);
                }
                return _dtPenaltyData;
            }
            catch
            {
                throw;
            }
        }

        public void InsertPenalty(lib06 objLib06)
        {
            try
            {
                string _todayDate = DateTime.Today.ToString("yyyy-MM-dd");
                List<lib02> _bookData = GetBookdata(objLib06.b06f02);

                using (DBManager objDBManager = new DBManager())
                {
                    objDBManager.Params.Add("b06f01", objLib06.b06f01);
                    objDBManager.Params.Add("b06f02", objLib06.b06f02);
                    objDBManager.Params.Add("b06f03", _bookData[0].b02f10);
                    objDBManager.Params.Add("b06f04", objLib06.b06f04);
                    objDBManager.Params.Add("b06f05", objLib06.b06f05);
                    objDBManager.Params.Add("b06f06", _todayDate);
                    objDBManager.ExecQueryWithParams("lib06");
                }
            }
            catch
            {
                throw;
            }
        }

        public string DeletePenaltyById(int bookId, int userId)
        {
            try
            {
                int _result;
                using (DBManager objDBManager = new DBManager())
                {
                    _query = string.Format(@"Delete                                                 
                                               FROM 
                                                     lib06
                                               WHERE 
                                                    b06f01 = @b06f01 && b06f02 = @b06f02");

                    objDBManager.WhereParams.Add("b06f01", userId);
                    objDBManager.WhereParams.Add("b06f02", bookId);
                    _result = objDBManager.DeleteDataWithParams(_query);
                }

                //if _result is 1 then query executed successully
                if (_result == 1)
                {
                    return "Penalty Deleted Successfully";
                }
                else
                {
                    return "Penalty not Deleted";
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
