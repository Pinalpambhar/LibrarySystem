using LibraryBusinessLogic.BL;
using LibraryBusinessLogic.Models;
using System.Web.Http;

namespace LibrarySystem.Controllers
{
    [Authorize]
    public class lib02Controller : ApiController
    {
        #region Private Members
        BLlib02 ObjBLlib02 = new BLlib02();
        #endregion Private Members

        #region Public Method
        /// <summary>
        /// Returns All Books Data
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "1,0")]
        [Route("api/GetAllBooks")]
        [HttpGet]
        public IHttpActionResult GetAllBooks()
        {
            return Ok(ObjBLlib02.GetAllBooks());
        }

        /// <summary>
        /// Return Specified Book Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [Route("api/GetBookById")]
        [HttpGet]
        public IHttpActionResult GetBookById(int id)
        {
            return Ok(ObjBLlib02.GetBookById(id));
        }

        /// <summary>
        /// Add New Book
        /// </summary>
        /// <param name="objlib02"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [Route("api/InsertBook")]
        [HttpPost]
        public IHttpActionResult InsertBook([FromBody] lib02 objlib02)
        {
            return Ok(ObjBLlib02.InsertBook(objlib02));
        }

        /// <summary>
        /// Update Book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objlib02"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [Route("api/UpdateBook")]
        [HttpPut]
        public IHttpActionResult UpdateBook([FromUri] int id, [FromBody] lib02 objlib02)
        {
            objlib02.b02f01 = id;
            return Ok(ObjBLlib02.UpdateBook(objlib02));
        }

        /// <summary>
        /// Delete Specified Book Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [Route("api/DeleteBookById")]
        [HttpDelete]
        public IHttpActionResult DeleteBookById(int id)
        {
            return Ok(ObjBLlib02.DeleteBookById(id));
        }

        #endregion Public Method
    }
}
