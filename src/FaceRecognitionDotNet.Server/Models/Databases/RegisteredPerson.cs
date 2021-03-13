using System;

namespace FaceRecognitionDotNet.Server.Models.Databases
{

    /// <summary>
    /// Represents a person who be registered to database.
    /// </summary>
    public sealed class RegisteredPerson
    {

        #region Properties

        /// <summary>
        /// A Id of this registered person.
        /// </summary>
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// A name of this registered person.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// A create datetime of this registered person data.
        /// </summary>
        public string CreatedDateTime
        {
            get;
            set;
        }

        #endregion

    }

}
