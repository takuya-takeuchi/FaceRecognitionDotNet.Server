using System.Collections.Generic;

namespace FaceRecognitionDotNet.Front.Models
{

    public sealed class DetectionViewModel
    {

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

    }

}