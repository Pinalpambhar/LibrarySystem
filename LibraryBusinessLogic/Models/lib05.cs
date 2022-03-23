using ServiceStack.DataAnnotations;
using System;

namespace LibraryBusinessLogic.Models
{
    /// <summary>
    /// Rent
    /// </summary>
    public class lib05
    {
        #region Public Property

        /// <summary>
        /// BookId
        /// </summary>
        [PrimaryKey]
        public int b05f01 { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        [PrimaryKey]
        public int b05f02 { get; set; }

        /// <summary>
        /// Days
        /// </summary>
        public int b05f03 { get; set; }

        /// <summary>
        /// IssueDate
        /// </summary>
        public DateTime b05f04 { get; set; }

        /// <summary>
        /// ReturnDate
        /// </summary>
        public DateTime b05f05 { get; set; }

        /// <summary>
        /// status
        /// </summary>
        public int b05f06 { get; set; }

        #endregion Public Property
    }
}
