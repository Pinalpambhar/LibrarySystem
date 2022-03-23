using ServiceStack.DataAnnotations;

namespace LibraryBusinessLogic.Models
{
    /// <summary>
    /// Book Type
    /// </summary>
    public class lib03
    {
        #region Public Property
        /// <summary>
        /// Book Type
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int b03f01 { get; set; }

        /// <summary>
        /// Book Type
        /// </summary>
        [StringLength(50)]
        public string b03f02 { get; set; }

        #endregion Public Property
    }
}
