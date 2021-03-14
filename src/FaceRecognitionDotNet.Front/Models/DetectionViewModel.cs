namespace FaceRecognitionDotNet.Front.Models
{

    public sealed class DetectionViewModel
    {

        #region Properties

        public ImageViewModel Image
        {
            get;
            set;
        }

        public DetectAreaModel[] DetectAreas
        {
            get;
            set;
        }

        #endregion

    }

}