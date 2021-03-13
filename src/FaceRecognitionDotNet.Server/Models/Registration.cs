using System.ComponentModel.DataAnnotations;

namespace FaceRecognitionDotNet.Server.Models
{

    /// <summary>
    /// Represents a registration data.
    /// </summary>
    public sealed class Registration
    {

        #region Properties

        /// <summary>
        /// The person demographics data.
        /// </summary>
        [Required]
        public Demographics Demographics
        {
            get;
            set;
        }

        /// <summary>
        /// The face encoding data.
        /// </summary>
        [Required]
        public Encoding Encoding
        {
            get;
            set;
        }

        /// <summary>
        /// The photo data.
        /// </summary>
        [Required]
        public Image Photo
        {
            get;
            set;
        }

        #endregion

    }

}
