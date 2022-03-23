using LibraryBusinessLogic.BL;
using LibraryBusinessLogic.Models;
using System.Web.Http;

namespace LibrarySystem.Controllers
{
    [Authorize]
    public class lib03Controller : ApiController
    {
        #region Private Members
        BLlib03 ObjBLlib03 = new BLlib03();
        #endregion Private Members

        #region Public Method

        /// <summary>
        /// Returns All Book Type
        /// </summary>
        /// <returns></returns>
        [Route("api/GetAllBookType")]
        [HttpGet]
        [Authorize(Roles = "1,0")]
        public IHttpActionResult GetAllBookType()
        {
            return Ok(ObjBLlib03.GetAllBookType());
        }

        /// <summary>
        /// Returns Specified Book Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/GetBookTypeById")]
        [HttpGet]
        [Authorize(Roles = "1,0")]
        public IHttpActionResult GetBookTypeById(int id)
        {
            return Ok(ObjBLlib03.GetBookTypeById(id));
        }

        /// <summary>
        /// Add New Book Type
        /// </summary>
        /// <param name="objLib03"></param>
        /// <returns></returns>
        [Route("api/InsertBookType")]
        [HttpPost]
        [Authorize(Roles = "1")]
        public IHttpActionResult InsertBookType([FromBody] lib03 objLib03)
        {
            return Ok(ObjBLlib03.InsertBookType(objLib03));
        }

        /// <summary>
        /// Update Book Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objLib03"></param>
        /// <returns></returns>
        [Route("api/UpdateBookType")]
        [HttpPut]
        [Authorize(Roles = "1")]
        public IHttpActionResult UpdateBookType([FromUri] int id, [FromBody] lib03 objLib03)
        {
            objLib03.b03f01 = id;
            return Ok(ObjBLlib03.UpdateBookType(objLib03));
        }

        /// <summary>
        /// Delete Specified Book Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/DeleteBookTypeById")]
        [HttpDelete]
        [Authorize(Roles = "1")]
        public IHttpActionResult DeleteBookTypeById(int id)
        {
            return Ok(ObjBLlib03.DeleteBookTypeById(id));
        }
        #endregion Public Method
    }
}
