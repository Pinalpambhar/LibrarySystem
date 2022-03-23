using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http.Filters;

namespace LibrarySystem.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        #region Private Members
        string _path;
        string _currentTime;
        #endregion

        #region Public Methods
        public ExceptionFilter() : base()
        {
            _currentTime = DateTime.UtcNow.ToShortDateString();
            _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Log/"), _currentTime + ".txt");

            //create File
            if (!File.Exists(_path))
            {
                var file = File.Create(_path);
                file.Close();
            }
        }

        public override void OnException(HttpActionExecutedContext ex)
        {

            string CurrentDateTime = DateTime.UtcNow.ToString();

            var stacktrace = new StackTrace(ex.Exception, true);
            var _frame = stacktrace.GetFrame(0);
            var jsonObject = new JObject();
            jsonObject.Add(" File: ", _frame.GetFileName());
            jsonObject.Add("Method:", _frame.GetMethod().Name);
            jsonObject.Add("LineNumber: ", _frame.GetFileLineNumber());
            jsonObject.Add("Message:", ex.Exception.Message);
            jsonObject.Add("StackStrace:", ex.Exception.StackTrace);
            base.OnException(ex);
            using (StreamWriter w = File.AppendText(_path))
            {
                string dt = DateTime.Now.ToString();
                w.WriteLine(CurrentDateTime + jsonObject);
            }

            ex.Response = ex.Request.CreateResponse(HttpStatusCode.BadRequest,ex.Exception.Message);
        }
        #endregion
    }
}