using System;
using System.ComponentModel.DataAnnotations;

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
        [Key]
        public Guid Id
        {
            get;
            set;
        }

        /// <summary>
        /// A first name of this registered person.
        /// </summary>
        [Required]
        public string FirstName
        {
            get;
            set;
        }

        /// <summary>
        /// A last name of this registered person.
        /// </summary>
        [Required]
        public string LastName
        {
            get;
            set;
        }

        /// <summary>
        /// A create datetime of this registered person data.
        /// </summary>
        [Required]
        public DateTime CreatedDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// A person photo data.
        /// </summary>
        [Required]
        public byte[] Photo
        {
            get;
            set;
        }

        #endregion

    }

}
