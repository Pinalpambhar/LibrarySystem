using ServiceStack.DataAnnotations;
using System;

namespace LibraryBusinessLogic.Models
{
    /// <summary>
    /// Book
    /// </summary>
    public class lib02
    {
        #region Public Property
        /// <summary>
        /// BookId
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int b02f01 { get; set; }

        /// <summary>
        /// BookName
        /// </summary>
        [StringLength(50)]
        public string b02f02 { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        [StringLength(50)]
        public string b02f03 { get; set; }

        /// <summary>
        /// Details
        /// </summary>
        [StringLength(200)]
        public string b02f04 { get; set; }

        /// <summary>
        /// Publication
        /// </summary>
        [StringLength(50)]
        public string b02f05 { get; set; }

        /// <summary>
        /// BookType
        /// </summary>
        [StringLength(50)]
        public string b02f06 { get; set; }

        /// <summary>
        /// Total Quantities
        /// </summary>
        public int b02f07 { get; set; }

        /// <summary>
        /// Available Quantities
        /// </summary>
        public int b02f08 { get; set; }

        /// <summary>
        /// Rent Quantities
        /// </summary>
        public int b02f09 { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal b02f10 { get; set; }

        /// <summary>
        /// Image 
        /// </summary>
        [StringLength(50)]
        public string b02f11 { get; set; }

        /// <summary>
        /// EntryDate
        /// </summary>
        public DateTime b02f12 { get; set; }

        #endregion Public Property
    }
}
