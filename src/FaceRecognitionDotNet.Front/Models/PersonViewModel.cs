using System;

namespace FaceRecognitionDotNet.Front.Models
{

    public sealed class PersonViewModel
    {

        #region Properties

        public Guid Id
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public DateTime CreatedDateTime
        {
            get;
            set;
        }

        public ImageViewModel Photo
        {
            get;
            set;
        }

        #endregion

    }

}