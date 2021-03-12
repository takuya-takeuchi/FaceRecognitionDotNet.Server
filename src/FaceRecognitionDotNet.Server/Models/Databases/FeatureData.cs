using System;

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
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// A Id that links to registered person.
        /// </summary>
        public Guid RegisteredPersonId
        {
            get;
            set;
        }

        /// <summary>
        /// A face encoding data.
        /// </summary>
        public byte[] Encoding
        {
            get;
            set;
        }

        #endregion

    }

}
