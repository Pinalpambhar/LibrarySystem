using ServiceStack.DataAnnotations;
using System;

namespace LibraryBusinessLogic.Models
{
    /// <summary>
    /// Penalty
    /// </summary>
    public class lib06
    {
        #region Public Property   

        /// <summary>
        /// UserId
        /// </summary>
        [PrimaryKey]
        public int b06f01 { get; set; }

        /// <summary>
        /// BookId
        /// </summary>
        [PrimaryKey]
        public int b06f02 { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal b06f03 { get; set; }

        /// <summary>
        /// Penalty
        /// </summary>
        public decimal b06f04 { get; set; }

        /// <summary>
        /// Details
        /// </summary>
        [StringLength(100)]
        public string b06f05 { get; set; }

        /// <summary>
        /// EntryDate
        /// </summary>
        public DateTime b06f06 { get; set; }

        #endregion Public Property
    }
}
