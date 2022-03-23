using LibraryBusinessLogic.BL;
using System.Web.Http;

namespace LibrarySystem.Controllers
{
    [Authorize]
    public class lib06Controller : ApiController
    {
        #region Private Members
        BLlib06 ObjBLlib06 = new BLlib06();
        #endregion Private Members

        #region Public Methods
        /// <summary>
        /// Returns All Penalties Data
        /// </summary>
        /// <returns></returns>
        [Route("api/GetAllPenalties")]
        [HttpGet]
        [Authorize(Roles = "1")]
        public IHttpActionResult GetAllPenalties()
        {
            return Ok(ObjBLlib06.GetAllPenalties());
        }

        /// <summary>
        /// Return Specified User Penalty Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/GetPenaltyById")]
        [HttpGet]
        [Authorize(Roles = "1,0")]
        public IHttpActionResult GetPenaltyById(int id)
        {
            return Ok(ObjBLlib06.GetPenaltyById(id));
        }

        /// <summary>
        /// Delete Penalty
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("api/DeletePenaltyById")]
        [HttpDelete]
        [Authorize(Roles = "1")]
        public IHttpActionResult DeletePenaltyById(int bookId, int userId)
        {
            return Ok(ObjBLlib06.DeletePenaltyById(bookId, userId));
        }
        #endregion Public Methods
    }
}
