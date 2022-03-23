using LibraryBusinessLogic.BL;
using LibraryBusinessLogic.Models;
using System.Web.Http;

namespace LibrarySystem.Controllers
{

    [AllowAnonymous]
    public class LoginController : ApiController
    {
        #region Private Members
        BLLogin objBLLogin = new BLLogin();
        #endregion

        #region Public Methods

        /// <summary>
        /// Checks if user is valid or not
        /// if user is valid it returns jwtToken
        /// </summary>
        /// <param name="objLogin"></param>
        /// <returns></returns>
        [Route("api/Authenticate")]
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] Login objLogin)
        {
            if(objBLLogin.Authentication(objLogin) != null)
            {
                return Ok(objBLLogin.Authentication(objLogin));
            }
            else
            {
                return Unauthorized();
            }

        }
        #endregion Public Methods
    }
}
