using System;
using System.ComponentModel.DataAnnotations;

namespace FaceRecognitionDotNet.Server.Models.Databases
{

    /// <summary>
    /// Represents a feature data.
    /// </summary>
    public sealed class FeatureData
    {

        #region Properties

        /// <summary>
        /// A Id of this feature data.
        /// </summary>
        [Required]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// A Id that links to registered person.
        /// </summary>
        [Required]
        public Guid RegisteredPersonId
        {
            get;
            set;
        }

        /// <summary>
        /// A face encoding data.
        /// </summary>
        [Required]
        public byte[] Encoding
        {
            get;
            set;
        }

        #endregion

    }

}
