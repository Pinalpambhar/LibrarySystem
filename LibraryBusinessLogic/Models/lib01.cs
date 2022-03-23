using ServiceStack.DataAnnotations;
using System;

namespace LibraryBusinessLogic.Models
{
    /// <summary>
    /// Users
    /// </summary>
    public class lib01
    {
        #region Public Property
        /// <summary>
        /// UserId  
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int b01f01 { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        [StringLength(50)]
        public string b01f02 { get; set; }

        /// <summary>
        /// MobileNumber
        /// </summary>
        public string b01f03 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [StringLength(50)]
        public string b01f04 { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [StringLength(50)]
        public string b01f05 { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [StringLength(50)]
        public string b01f06 { get; set; }

        /// <summary>
        /// IsLibrarian
        /// </summary>
        public int b01f07 { get; set; }

        /// <summary>
        /// EntryDate
        /// </summary>
        public DateTime b01f08 { get; set; }

        #endregion Public Property
    }
}
