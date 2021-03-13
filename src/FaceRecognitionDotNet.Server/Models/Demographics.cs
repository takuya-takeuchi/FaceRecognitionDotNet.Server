using System;
using System.ComponentModel.DataAnnotations;

namespace FaceRecognitionDotNet.Server.Models
{

    /// <summary>
    /// Represents a demographics data.
    /// </summary>
    public sealed class Demographics
    {

        #region Properties

        /// <summary>
        /// The first name.
        /// </summary>
        [Required]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// The last name.
        /// </summary>
        [Required]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// The create datetime.
        /// </summary>
        [Required]
        public DateTime CreatedDateTime
        {
            get;
            set;
        }

        #endregion

    }

}
