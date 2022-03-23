using ServiceStack.DataAnnotations;

namespace LibraryBusinessLogic.Models
{
    /// <summary>
    /// Publication
    /// </summary>
    public class lib04
    {
        #region Public Property
        /// <summary>
        /// PublicationId
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int b04f01 { get; set; }

        /// <summary>
        /// PublicationName
        /// </summary>
        [StringLength(50)]
        public string b04f02 { get; set; }

        #endregion Public Property
    }
}
