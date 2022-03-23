using LibraryBusinessLogic.BL;
using LibraryBusinessLogic.Models;
using System.Web.Http;

namespace LibrarySystem.Controllers
{
    [Authorize]
    [Authorize(Roles = "1")]
    public class lib01Controller : ApiController
    {
        #region Private Members
        BLlib01 ObjBLlib01 = new BLlib01();
        #endregion Private Members

        #region Public Methods
        /// <summary>
        /// returns All Users Data
        /// </summary>
        /// <returns></returns>
        [Route("api/GetAllUser")]
        [HttpGet]
        public IHttpActionResult GetAllUser()
        {
            return Ok(ObjBLlib01.GetAllUsers());
        }

        /// <summary>
        /// Return Specified User Data
        /// </summary>
        /// <param name="id">UserId</param>
        /// <returns></returns>
        [Route("api/GetUserById")]
        [HttpGet]
        public IHttpActionResult GetUserById(int id)
        {
            return Ok(ObjBLlib01.GetUserById(id));
        }

        /// <summary>
        /// Add New User
        /// </summary>
        /// <param name="objLib01"></param>
        [Route("api/InsertUser")]
        [HttpPost]
        public IHttpActionResult InsertUser([FromBody] lib01 objLib01)
        {
            return Ok(ObjBLlib01.InsertUser(objLib01));
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [Route("api/UpdateUser")]
        [HttpPut]
        public IHttpActionResult UpdateUser([FromUri]int id, [FromBody] lib01 objLib01)
        {
            objLib01.b01f01 = id;
            return Ok(ObjBLlib01.UpdateUser(objLib01));
        }

        /// <summary>
        /// Delete Specified User Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/DeleteUserById")]
        [HttpDelete]
        public IHttpActionResult DeleteUserById(int id)
        {
            return Ok(ObjBLlib01.DeleteUserById(id));
        }
        #endregion Public Methods
    }
}
