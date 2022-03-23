using LibraryBusinessLogic.BL;
using LibraryBusinessLogic.Models;
using System.Web.Http;

namespace LibrarySystem.Controllers
{
    [Authorize]
    public class lib05Controller : ApiController
    {
        #region Private Members
        BLlib05 ObjBLlib05 = new BLlib05();
        #endregion Private Members

        #region Public Methods

        /// <summary>
        /// Retrieve All Rented Books
        /// </summary>
        /// <returns></returns>
        [Route("api/GetAllIssuedBooks")]
        [HttpGet]
        [Authorize(Roles = "1")]
        public IHttpActionResult GetAllIssuedBooks()
        {
            return Ok(ObjBLlib05.GetAllRents());
        }

        /// <summary>
        /// Retrieve Rented Book By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/GetIssuedBookByRentId")]
        [HttpGet]
        [Authorize(Roles = "1,0")]
        public IHttpActionResult GetIssuedBookByRentId(int id)
        {
            return Ok(ObjBLlib05.GetRentById(id));
        }

        /// <summary>
        /// Retrieve Rented Book By UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/GetIssuedBookByUserId")]
        [HttpGet]
        [Authorize(Roles = "1,0")]
        public IHttpActionResult GetRentByUserId(int userId)
        {
            return Ok(ObjBLlib05.GetRentById(userId));
        }

        /// <summary>
        /// Issue Book
        /// </summary>
        /// <param name="objLib05"></param>
        /// <returns></returns>
        [Route("api/IssueBook")]
        [HttpPost]
        [Authorize(Roles = "1")]
        public IHttpActionResult IssueBook([FromBody] lib05 objLib05)
        {
            //return Ok(ObjBLlib05.InsertRent(objLib05));
            return Ok(BLlib05.BookOperations(objLib05));
        }

        /// <summary>
        /// Return Book
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("api/ReturnBook")]
        [HttpPut]
        [Authorize(Roles = "1")]
        public IHttpActionResult ReturnBook(int bookId, int userId)
        {
            return Ok(ObjBLlib05.UpdateRent(bookId, userId));
        }

        #endregion
    }
}
