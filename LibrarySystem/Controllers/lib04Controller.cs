using LibraryBusinessLogic.BL;
using LibraryBusinessLogic.Models;
using System.Web.Http;

namespace LibrarySystem.Controllers
{
    [Authorize]
    public class lib04Controller : ApiController
    {
        #region Private Members
        BLlib04 ObjBLlib04 = new BLlib04();
        #endregion Private Members

        #region Public Method

        /// <summary>
        /// Returns All Publication
        /// </summary>
        /// <returns></returns>
        [Route("api/GetAllPublication")]
        [HttpGet]
        [Authorize(Roles = "1,0")]
        public IHttpActionResult GetAllPublication()
        {
            return Ok(ObjBLlib04.GetAllPublication());
        }

        /// <summary>
        /// Returns Specified Publication
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/GetPublicationById")]
        [HttpGet]
        [Authorize(Roles = "1,0")]
        public IHttpActionResult GetPublicationById(int id)
        {
            return Ok(ObjBLlib04.GetPublicationById(id));
        }

        /// <summary>
        /// Add New Publication
        /// </summary>
        /// <param name="objLib04"></param>
        /// <returns></returns>
        [Route("api/InsertPublication")]
        [HttpPost]
        [Authorize(Roles = "1")]
        public IHttpActionResult InsertPublication([FromBody] lib04 objLib04)
        {
            return Ok(ObjBLlib04.InsertPublication(objLib04));
        }

        /// <summary>
        /// Update Publication
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objLib04"></param>
        /// <returns></returns>
        [Route("api/UpdatePublication")]
        [HttpPut]
        [Authorize(Roles = "1")]
        public IHttpActionResult UpdatePublication([FromUri] int id, [FromBody] lib04 objLib04)
        {
            objLib04.b04f01 = id;
            return Ok(ObjBLlib04.UpdatePublication(objLib04));
        }

        /// <summary>
        /// Delete Specified Publication
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/DeletePublicationById")]
        [HttpDelete]
        [Authorize(Roles = "1")]
        public IHttpActionResult DeletePublicationById(int id)
        {
            return Ok(ObjBLlib04.DeletePublicationById(id));
        }
        #endregion Public Method
    }
}
